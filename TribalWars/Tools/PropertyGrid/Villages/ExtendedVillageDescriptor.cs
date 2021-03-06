using System.ComponentModel;
using TribalWars.Tools.PropertyGrid.Tribes;
using TribalWars.Villages;

namespace TribalWars.Tools.PropertyGrid.Villages
{
    /// <summary>
    /// Village descriptor for a PropertyGrid
    /// </summary>
    [TypeConverter(typeof(PropertySorter))]
    public class ExtendedVillageDescriptor
    {
        #region Constants
        protected const string PROPERTY_CATEGORY = "Village";
        #endregion

        #region Fields
        private Village _village;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the underlying village
        /// </summary>
        [Browsable(false)]
        public Village Village
        {
            get { return _village; }
        }
	
        #endregion

        #region Constructors
        public ExtendedVillageDescriptor(Village vil)
        {
            _village = vil;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return Village.PointsWithDiff;
        }
        #endregion

        #region Properties
        [Category(PROPERTY_CATEGORY), PropertyOrder(10)]
        public string Name
        {
            get { return Village.Name; }
            set { }
        }

        [Category(PROPERTY_CATEGORY), PropertyOrder(12)]
        public string Points
        {
            get { return Village.PointsWithDiff; }
            set { }
        }

        [Category(PROPERTY_CATEGORY), PropertyOrder(15), Editor(typeof(VillagePointerUiEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Location
        {
            get { return Village.LocationString; }
            set { }
        }

        [Category(PROPERTY_CATEGORY), PropertyOrder(20)]
        public VillagePlayerDescriptor Player
        {
            get
            {
                if (Village.HasPlayer)
                {
                    return new VillagePlayerDescriptor(Village.Player);
                }
                else
                {
                    return null;
                }
            }
            set { }
        }

        [Category(PROPERTY_CATEGORY), PropertyOrder(25)]
        public TribeDescriptor Tribe
        {
            get
            {
                if (Village.HasTribe)
                    return new TribeDescriptor(Village.Player.Tribe);
                else
                    return null;
            }
            set { }
        }

        [Category(PROPERTY_CATEGORY), PropertyOrder(50), Editor(typeof(ClipboardCopierUiEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string BBCode
        {
            get { return Village.BbCode(); }
            set { }
        }
        #endregion
    }
}
