using System;
using System.Collections.ObjectModel;

namespace Week2MondayHttp
{
    public class Scrapper
    {
        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }
    }
}
