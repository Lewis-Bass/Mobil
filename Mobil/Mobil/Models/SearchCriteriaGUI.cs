
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mobil.Models
{
    public class SearchCriteriaGUI : SearchCriteriaBase, INotifyPropertyChanged
    {
        #region Constructor

        public SearchCriteriaGUI() { }

        #endregion

        #region Binding Sources

        public List<string> SearchFields
        {
            get
            {
                return new List<string>
                {

                    "Path",
                    "FileName",
                    "Extension",
                    "Date",
                    "Locked",
                    //{ "Prior Versions", "Prior Version" },

                };
            }
        }

        public List<string> SearchHow
        {
            get
            {
                return new List<string>
                {
                    "=",
                    "<",
                    "<=",
                    ">",
                    ">=",
                    "<>",
                    "Range",
                    "Matches",
                    //{ "List", "List"},
                };
            }
        }

        public List<string> RelationshipFields
        {
            get
            {
                return new List<string>
                {
                    "And",
                    "Or"
                };
            }
        }


        //public Dictionary<string, string> GroupRelationshipFields
        //{
        //    get
        //    {
        //        return new Dictionary<string, string>
        //        {
        //            { "&", "/Resources/GroupAnd100-71.png"},
        //            { "^", "/Resources/GroupOr100-71.png"},
        //            { "!", "/Resources/GroupNot100-71.png"},
        //        };
        //    }
        //}

        //public List<RelationshipCriteria> GroupRelationshipFields
        //{
        //    get
        //    {
        //        return new List<RelationshipCriteria>
        //        {
        //            new RelationshipCriteria
        //            {
        //                Key = "&",
        //                Value ="/Resources/GroupAnd100-71.png",
        //                ToolTip = Resources.Resource.RelationshipAndHelp
        //            },
        //            new RelationshipCriteria
        //            {
        //                Key = "^",
        //                Value ="/Resources/GroupOr100-71.png",
        //                ToolTip = Resources.Resource.RelationshipOrHelp
        //            }
        //        };
        //    }
        //}

        #endregion

        #region GUI only properties

        public bool ShowValueMin
        {
            get
            {
                return (Field != "Locked" && Field != "Prior Versions" && Field != "Date");
            }
        }

        public bool ShowValueMax
        {
            get
            {
                return (Criteria == "Range" && Field != "Locked" && Field != "Prior Versions" && Field != "Date");
            }
        }

        public bool ShowValueBool
        {
            get
            {
                return (Field == "Locked" || Field == "Prior Versions");
            }
        }

        public bool ShowCriteria
        {
            get
            {
                return (Field != "Locked" && Field != "Prior Versions");
            }
        }

        public bool ShowValueMinDate
        {
            get
            {
                return (Field == "Date");
            }
        }

        public bool ShowValueMaxDate
        {
            get
            {
                return (Field == "Date" && Criteria == "Range");
            }
        }

        public bool ShowTo
        {
            get
            {
                return (Criteria == "Range");
            }
        }

        public bool ShowGroupBorder
        {
            get
            {
                return (GroupID > 0);
            }
        }

        bool _showRelationship = true;
        public bool ShowRelationship
        {
            get { return _showRelationship; }
            set
            {
                if (value != _showRelationship)
                {
                    _showRelationship = value;
                    OnPropertyChanged("ShowRelationship");
                }
            }
        }

        bool _showGroupRelationship = false;
        public bool ShowGroupRelationship
        {
            get { return _showGroupRelationship; }
            set
            {
                if (value != _showGroupRelationship)
                {
                    _showGroupRelationship = value;
                    OnPropertyChanged("ShowGroupRelationship");
                }
            }
        }

        #endregion

        #region Input Fields

        bool _select = false;
        /// <summary>
        /// Is the row currently selected
        /// </summary>
        public bool Select
        {
            get { return _select; }
            set
            {
                if (value != _select)
                {
                    _select = value;
                    OnPropertyChanged("Select");
                }
            }
        }

        string _groupColor = "Transparent";
        public string GroupColor
        {
            get { return _groupColor; }
            set
            {
                if (value != _groupColor)
                {
                    _groupColor = value;
                    OnPropertyChanged("GroupColor");
                }
            }
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// raise additional events that are found in the GUI
        /// </summary>
        public override void NotifyShows()
        {
            OnPropertyChanged("ShowValueMin");
            OnPropertyChanged("ShowValueMax");
            OnPropertyChanged("ShowValueBool");
            OnPropertyChanged("ShowCriteria");
            OnPropertyChanged("ShowValueMinDate");
            OnPropertyChanged("ShowValueMaxDate");
            OnPropertyChanged("ShowTo");
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
