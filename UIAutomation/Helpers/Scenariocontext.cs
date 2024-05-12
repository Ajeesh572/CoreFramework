namespace UIAutomation.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Contexts;
    public class Scenariocontext
    {

        private IDictionary<string, Object> scenarioContext;

        public Scenariocontext()
        {
            scenarioContext = new Dictionary<string, Object>();
        }

        public void setContext(string key, Object value)
        {
            scenarioContext.Add(key, value);
        }

        public Object getContext(string key)
        {
            return scenarioContext[key];
        }

        public Boolean isContains(string key)
        {
            return scenarioContext.ContainsKey(key);
        }
    }
}
