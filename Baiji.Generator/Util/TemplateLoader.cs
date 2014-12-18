using System;
using System.Collections.Generic;
using Antlr4.StringTemplate;
using Antlr4.StringTemplate.Misc;
using CTripOSS.Baiji.Generator.Properties;
using log4net;

namespace CTripOSS.Baiji.Generator.Util
{
    public class TemplateLoader
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TemplateLoader));

        private readonly ITemplateErrorListener ERROR_LISTENER = new LoaderErrorListener();

        private readonly IList<string> _templateNames;
        private volatile TemplateGroup _templateGroup;

        private readonly IDictionary<Type, IAttributeRenderer> attributeRenderers =
            new Dictionary<Type, IAttributeRenderer>();

        public TemplateLoader(IList<string> templateNames)
        {
            _templateNames = templateNames;
        }

        public TemplateLoader(IList<string> templateNames, IDictionary<Type, IAttributeRenderer> attributeRenderers)
            : this(templateNames)
        {
            this.attributeRenderers = attributeRenderers;
        }

        public Template Load(string templateName)
        {
            var tg = GetTemplateGroup(_templateNames);
            return tg.GetInstanceOf(templateName);
        }

        protected TemplateGroup GetTemplateGroup(IList<string> templateNames)
        {
            if (_templateGroup == null)
            {
                // Combile the header and all .st files and load everything into a TemplateGroup
                _templateGroup = new TemplateGroup();
                foreach (var templateName in templateNames)
                {
                    _templateGroup.ImportTemplates(GetTemplateGroupFromResource(templateName));
                }
                foreach (var type in attributeRenderers.Keys)
                {
                    var renderer = attributeRenderers[type];
                    _templateGroup.RegisterRenderer(type, renderer);
                }
            }
            return _templateGroup;
        }

        protected TemplateGroup GetTemplateGroupFromResource(string templateName)
        {
            var tg = new TemplateGroupString(templateName.Replace("_", "."),
                Resources.ResourceManager.GetString(templateName));
            tg.ErrorManager = new ErrorManager(ERROR_LISTENER);
            tg.Load();
            return tg;
        }

        private class LoaderErrorListener : ITemplateErrorListener
        {
            public void CompiletimeError(TemplateMessage msg)
            {
                Log.Error(msg.ToString());
            }

            public void IOError(TemplateMessage msg)
            {
                Log.Error(msg.ToString());
            }

            public void InternalError(TemplateMessage msg)
            {
                Log.Error(msg.ToString());
            }

            public void RuntimeError(TemplateMessage msg)
            {
                Log.Error(msg.ToString());
            }
        }
    }
}