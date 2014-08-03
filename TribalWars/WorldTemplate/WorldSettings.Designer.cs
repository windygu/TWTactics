// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.32989
//    <NameSpace>TribalWars.WorldTemplate</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>True</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>True</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>False</GenerateXMLAttributes><OrderXMLAttrib>False</OrderXMLAttrib><EnableEncoding>False</EnableEncoding><AutomaticProperties>True</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>ASCII</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace TribalWars.WorldTemplate
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;


    public partial class WorldConfiguration
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string serverField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nameField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string offsetField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string speedField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string unitSpeedField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string dataVillageField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string dataPlayerField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string dataTribeField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string gameVillageField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string guestPlayerField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string guestTribeField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string tWStatsGeneralField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string tWStatsVillageField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string tWStatsPlayerField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string tWStatsTribeField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string tWStatsPlayerGraphField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string tWStatsTribeGraphField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string worldDatSceneryField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private List<WorldConfigurationBuildingsBuilding> buildingsField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private List<WorldConfigurationUnitsUnit> unitsField;

        private static System.Xml.Serialization.XmlSerializer serializer;

        public string Server { get; set; }

        public string Name { get; set; }

        public string Offset { get; set; }

        public string Speed { get; set; }

        public string UnitSpeed { get; set; }

        public string DataVillage { get; set; }

        public string DataPlayer { get; set; }

        public string DataTribe { get; set; }

        public string GameVillage { get; set; }

        public string GuestPlayer { get; set; }

        public string GuestTribe { get; set; }

        public string TWStatsGeneral { get; set; }

        public string TWStatsVillage { get; set; }

        public string TWStatsPlayer { get; set; }

        public string TWStatsTribe { get; set; }

        public string TWStatsPlayerGraph { get; set; }

        public string TWStatsTribeGraph { get; set; }

        public string WorldDatScenery { get; set; }


        public WorldConfiguration()
        {
            this.unitsField = new List<WorldConfigurationUnitsUnit>();
            this.buildingsField = new List<WorldConfigurationBuildingsBuilding>();
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Building", typeof(WorldConfigurationBuildingsBuilding), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<WorldConfigurationBuildingsBuilding> Buildings
        {
            get
            {
                return this.buildingsField;
            }
            set
            {
                this.buildingsField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Unit", typeof(WorldConfigurationUnitsUnit), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<WorldConfigurationUnitsUnit> Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        private static System.Xml.Serialization.XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WorldConfiguration));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current WorldConfiguration object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an WorldConfiguration object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output WorldConfiguration object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out WorldConfiguration obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WorldConfiguration);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out WorldConfiguration obj)
        {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }

        public static WorldConfiguration Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                return ((WorldConfiguration)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current WorldConfiguration object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an WorldConfiguration object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output WorldConfiguration object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out WorldConfiguration obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WorldConfiguration);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out WorldConfiguration obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static WorldConfiguration LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }

    public partial class WorldConfigurationBuildingsBuilding
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nameField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string typeField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string imageField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string pointsField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string productionField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string peopleField;

        private static System.Xml.Serialization.XmlSerializer serializer;

        public string Name { get; set; }

        public string Type { get; set; }

        public string Image { get; set; }

        public string Points { get; set; }

        public string Production { get; set; }

        public string People { get; set; }


        private static System.Xml.Serialization.XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WorldConfigurationBuildingsBuilding));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current WorldConfigurationBuildingsBuilding object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an WorldConfigurationBuildingsBuilding object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output WorldConfigurationBuildingsBuilding object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out WorldConfigurationBuildingsBuilding obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WorldConfigurationBuildingsBuilding);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out WorldConfigurationBuildingsBuilding obj)
        {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }

        public static WorldConfigurationBuildingsBuilding Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                return ((WorldConfigurationBuildingsBuilding)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current WorldConfigurationBuildingsBuilding object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an WorldConfigurationBuildingsBuilding object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output WorldConfigurationBuildingsBuilding object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out WorldConfigurationBuildingsBuilding obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WorldConfigurationBuildingsBuilding);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out WorldConfigurationBuildingsBuilding obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static WorldConfigurationBuildingsBuilding LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }

    public partial class WorldConfigurationUnitsUnit
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string positionField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nameField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string shortField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string typeField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string carryField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string farmerField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string hideAttackerField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string speedField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string offenseField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string costWoodField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string costClayField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string costIronField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string costPeopleField;

        private static System.Xml.Serialization.XmlSerializer serializer;

        public string Position { get; set; }

        public string Name { get; set; }

        public string Short { get; set; }

        public string Type { get; set; }

        public string Carry { get; set; }

        public string Farmer { get; set; }

        public string HideAttacker { get; set; }

        public string Speed { get; set; }

        public string Offense { get; set; }

        public string CostWood { get; set; }

        public string CostClay { get; set; }

        public string CostIron { get; set; }

        public string CostPeople { get; set; }


        private static System.Xml.Serialization.XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(WorldConfigurationUnitsUnit));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current WorldConfigurationUnitsUnit object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an WorldConfigurationUnitsUnit object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output WorldConfigurationUnitsUnit object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out WorldConfigurationUnitsUnit obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WorldConfigurationUnitsUnit);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out WorldConfigurationUnitsUnit obj)
        {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }

        public static WorldConfigurationUnitsUnit Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                return ((WorldConfigurationUnitsUnit)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current WorldConfigurationUnitsUnit object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an WorldConfigurationUnitsUnit object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output WorldConfigurationUnitsUnit object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out WorldConfigurationUnitsUnit obj, out System.Exception exception)
        {
            exception = null;
            obj = default(WorldConfigurationUnitsUnit);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out WorldConfigurationUnitsUnit obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static WorldConfigurationUnitsUnit LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }

    public partial class NewDataSet
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private List<WorldConfiguration> itemsField;

        private static System.Xml.Serialization.XmlSerializer serializer;

        public NewDataSet()
        {
            this.itemsField = new List<WorldConfiguration>();
        }

        public List<WorldConfiguration> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        private static System.Xml.Serialization.XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(NewDataSet));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current NewDataSet object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an NewDataSet object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output NewDataSet object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out NewDataSet obj, out System.Exception exception)
        {
            exception = null;
            obj = default(NewDataSet);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out NewDataSet obj)
        {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }

        public static NewDataSet Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                return ((NewDataSet)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current NewDataSet object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an NewDataSet object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output NewDataSet object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out NewDataSet obj, out System.Exception exception)
        {
            exception = null;
            obj = default(NewDataSet);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out NewDataSet obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static NewDataSet LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }
}
