﻿using EAAddInBase.MDGBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMentor.ADTechnology
{
    public static class ConnectorStereotypes
    {
        public static readonly ConnectorStereotype AddressedBy = new ConnectorStereotype(
            name: "adAddressedBy",
            displayName: "Addressed By",
            reverseDisplayName: "Addresses",
            type: ConnectorType.Association,
            direction: Direction.SourceToDestination,
            compositionKind: CompositionKind.AggregateAtSource,
            connects: new[]{
                new Connection(from: ProblemSpace.Problem, to: ProblemSpace.Option),
                new Connection(from: SolutionSpace.ProblemOccurrence, to: SolutionSpace.OptionOccurrence)
            });

        public static readonly ConnectorStereotype Raises = new ConnectorStereotype(
            name: "adRaises",
            displayName: "Raises",
            reverseDisplayName: "Raised By",
            type: ConnectorType.Association,
            direction: Direction.SourceToDestination,
            connects: new[]{
                new Connection(from: ProblemSpace.Option, to: ProblemSpace.Problem),
                new Connection(from: SolutionSpace.OptionOccurrence, to: SolutionSpace.ProblemOccurrence),
                new Connection(from: ProblemSpace.Problem, to: ProblemSpace.Problem),
                new Connection(from: SolutionSpace.ProblemOccurrence, to: SolutionSpace.ProblemOccurrence),
                new Connection(from: ProblemSpace.Option, to: ProblemSpace.ProblemSpacePackage.Element),
                new Connection(from: SolutionSpace.OptionOccurrence, to: SolutionSpace.SolutionSpacePackage.Element),
                new Connection(from: ProblemSpace.Problem, to: ProblemSpace.ProblemSpacePackage.Element),
                new Connection(from: SolutionSpace.ProblemOccurrence, to: SolutionSpace.SolutionSpacePackage.Element),
                new Connection(from: ProblemSpace.ProblemSpacePackage.Element, to: ProblemSpace.ProblemSpacePackage.Element),
                new Connection(from: SolutionSpace.SolutionSpacePackage.Element, to: SolutionSpace.SolutionSpacePackage.Element)
            });

        public static readonly ConnectorStereotype Suggests = new ConnectorStereotype(
            name: "adSuggests",
            displayName: "Suggests",
            reverseDisplayName: "Suggested By",
            type: ConnectorType.Dependency,
            direction: Direction.SourceToDestination,
            connects: new[]{
                new Connection(from: ProblemSpace.Option, to: ProblemSpace.Option),
                new Connection(from: SolutionSpace.OptionOccurrence, to: SolutionSpace.OptionOccurrence),
                new Connection(from: ElementType.Issue.DefaultStereotype, to: SolutionSpace.OptionOccurrence),
                new Connection(from: ElementType.Requirement.DefaultStereotype, to: SolutionSpace.OptionOccurrence)
            });

        public static readonly ConnectorStereotype ConflictsWith = new ConnectorStereotype(
            name: "adConflictsWith",
            displayName: "Conflicts With",
            type: ConnectorType.Dependency,
            direction: Direction.BiDirectional,
            connects: new[]{
                new Connection(from: ProblemSpace.Option, to: ProblemSpace.Option),
                new Connection(from: SolutionSpace.OptionOccurrence, to: SolutionSpace.OptionOccurrence)
            });

        public static readonly ConnectorStereotype BoundTo = new ConnectorStereotype(
            name: "adBoundTo",
            displayName: "Bound To",
            type: ConnectorType.Dependency,
            direction: Direction.BiDirectional,
            connects: new[]{
                new Connection(from: ProblemSpace.Option, to: ProblemSpace.Option),
                new Connection(from: SolutionSpace.OptionOccurrence, to: SolutionSpace.OptionOccurrence)
            });

        public static readonly ConnectorStereotype Challenges = new ConnectorStereotype(
            name: "adChallenges",
            displayName: "Challenges",
            reverseDisplayName: "Challenged By",
            type: ConnectorType.Dependency,
            direction: Direction.SourceToDestination,
            connects: new[]{
                new Connection(from: ElementType.Issue.DefaultStereotype, to: SolutionSpace.OptionOccurrence),
                new Connection(from: ElementType.Requirement.DefaultStereotype, to: SolutionSpace.OptionOccurrence)
            });

        public static readonly ConnectorStereotype Overrides = new ConnectorStereotype(
            name: "adOverrides",
            displayName: "Overrides",
            reverseDisplayName: "Overriden By",
            type: ConnectorType.Association,
            direction: Direction.SourceToDestination,
            connects: new[]{
                new Connection(from: SolutionSpace.OptionOccurrence, to: SolutionSpace.OptionOccurrence),
                new Connection(from: SolutionSpace.ProblemOccurrence, to: SolutionSpace.ProblemOccurrence)
            });

        public static readonly ConnectorStereotype AssessesPositively = new ConnectorStereotype(
            name: "adAssessesPositively",
            displayName: "Assesses Positively",
            reverseDisplayName: "Positively Assessed By",
            type: ConnectorType.Association,
            direction: Direction.SourceToDestination,
            connects: new[]{
                new Connection(from: ElementType.Requirement.DefaultStereotype, to: ProblemSpace.Option)
            });

        public static readonly ConnectorStereotype AssessesNegatively = new ConnectorStereotype(
            name: "adAssessesNegatively",
            displayName: "Assesses Negatively",
            reverseDisplayName: "Negatively Assessed By",
            type: ConnectorType.Dependency,
            direction: Direction.SourceToDestination,
            connects: new[]{
                new Connection(from: ElementType.Requirement.DefaultStereotype, to: ProblemSpace.Option)
            });
    }
}
