using System;
namespace Week2CLIAPI
{
    public class Todo
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool done = false;
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

    }
}
