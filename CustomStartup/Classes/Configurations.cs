using System.Collections.Generic;

namespace CustomStartup.Classes {
    public class Configurations {
        public List<Config> Configs { get; set; }
    }

    public class Config {
        public string Network { get; set; }
        public IList<string> Close { get; set; }
        public IList<string> Start { get; set; }
        public bool RunAlways { get; set; }
    }
}
