﻿using ADMentor.DataAccess;
using EAAddInBase;
using EAAddInBase.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAddInBase.Utils;

namespace ADMentor.CopyMetadata
{
    sealed class UpdateProblemOccurrenceStateOnAlternativeRemoved : ICommand<OptionOccurrence, DeleteEntity>
    {
        private readonly ModelEntityRepository Repo;

        public UpdateProblemOccurrenceStateOnAlternativeRemoved(ModelEntityRepository repo)
        {
            Repo = repo;
        }

        public DeleteEntity Execute(OptionOccurrence alternative)
        {
            alternative.AssociatedProblemOccurrences(Repo.GetElement).ForEach(problemOccurrence =>
            {
                var alternatives = from alt in problemOccurrence.Alternatives(Repo.GetElement)
                                   where !alt.Equals(alternative)
                                   select alt;

                problemOccurrence.State = problemOccurrence.DeduceState(alternatives);

                Repo.PropagateChanges(problemOccurrence);
            });

            return DeleteEntity.Delete;
        }

        public bool CanExecute(OptionOccurrence _)
        {
            return true;
        }

        public ICommand<ModelEntity, DeleteEntity> AsOnDeleteEntityHandler()
        {
            return this.Adapt((ModelEntity entity) => {
                return entity.TryCast<OptionOccurrence>().OrElse(() =>
                {
                    return from connector in entity.TryCast<ModelEntity.Connector>()
                           from target in connector.Target(Repo.GetElement)
                           from oo in target.TryCast<OptionOccurrence>()
                           select oo;
                });
            });
        }
    }
}
