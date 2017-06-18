using System;

namespace DateTimeValidate {
    class Program {
        static void Main(string[] args) {

        }
    }

    public class ExtractAndOverrideDateTime {

        private DateTime? _now;

        internal DateTime Now {
            get { return _now ?? DateTime.Now; }
            set { _now = value; }
        }

        public DateTime CheckDate() {
            return Now;
        }
    }

    public class TestProgram {

        INewDateTime dateTimeObjet;

        public TestProgram(INewDateTime dateTimeObjet) {
            this.dateTimeObjet = dateTimeObjet;
        }

        public string Test() {
            return dateTimeObjet.GetNow().ToString("yyyy/MM/dd");
        }
    }
    public class NewDateTime : INewDateTime {

        public DateTime GetNow() {
            return DateTime.Now;
        }
    }
    public interface INewDateTime {

        DateTime GetNow();
    }

}
