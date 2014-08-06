﻿using AdAddIn.ADTechnology;
using EAAddInFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AdAddIn.PopulateDependencies
{
    public class DependencyTree
    {
        public DependencyTree(EA.Element element, Option<EA.Connector> incomingConnector, IEnumerable<DependencyTree> children)
        {
            Element = element;
            IcomingConnector = incomingConnector;
            Children = children;
        }

        public EA.Element Element { get; private set; }

        public Option<EA.Connector> IcomingConnector { get; private set; }

        public IEnumerable<DependencyTree> Children { get; private set; }

        public static DependencyTree Create(EA.Repository repo, EA.Element rootNode, int levels)
        {
            Debug.Assert(levels > 0);

            return Create(repo, rootNode, Options.None<EA.Connector>(), levels).First();
        }

        private static Option<DependencyTree> Create(EA.Repository repo, EA.Element rootNode, Option<EA.Connector> incomingEdge, int levels)
        {
            if (levels > 0)
            {
                var children = from c in rootNode.Connectors.Cast<EA.Connector>()
                               from target in DescendToElement(repo, rootNode, c)
                               from childTree in Create(repo, target, Options.Some(c), levels - 1)
                               select childTree;
                return Options.Some(new DependencyTree(rootNode, incomingEdge, children));
            }
            else
            {
                return Options.None<DependencyTree>();
            }
        }

        private static Option<EA.Element> DescendToElement(EA.Repository repo, EA.Element source, EA.Connector connector)
        {
            if (connector.Is(ConnectorStereotypes.AlternativeFor) && connector.SupplierID == source.ElementID)
            {
                return from target in repo.TryGetElement(connector.ClientID)
                       select target;
            }
            if (connector.Is(ConnectorStereotypes.Includes) && connector.ClientID == source.ElementID)
            {
                return from target in repo.TryGetElement(connector.SupplierID)
                       select target;
            }
            return Options.None<EA.Element>();
        }
    }
}