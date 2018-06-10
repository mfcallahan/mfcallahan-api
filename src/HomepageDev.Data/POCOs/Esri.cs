using System.Collections.Generic;

namespace HomepageDev.Data.POCOs
{
    public class FeatureLayer
    {
        public bool showLegend { get; set; }
        public bool visibility { get; set; }
        public int opacity { get; set; }
        public List<Layer> layers { get; set; }

    }

    public class Layer
    {
        public LayerDefinition layerDefinition { get; set; }
        public FeatureSet featureSet { get; set; }
        public int nextObjectId { get; set; }
        public PopupInfo popupInfo { get; set; }
    }

    public class LayerDefinition
    {
        public string geometryType { get; set; }
        public string objectIdField { get; set; }
        public string type { get; set; }
        public string typeIdField { get; set; }
        public DrawingInfo drawingInfo { get; set; }
        public List<Field> fields { get; set; }
        public List<object> types { get; set; }
        public string capabilities { get; set; }
        public string name { get; set; }
        public Extent extent { get; set; }
        public List<object> templates { get; set; }
        public int minScale { get; set; }
        public int maxScale { get; set; }
        public SpatialReference2 spatialReference { get; set; }
    }

    public class FeatureSet
    {
        public List<Feature> features { get; set; }
        public string geometryType { get; set; }
    }

    public class PopupInfo
    {
        public string title { get; set; }
        public List<FieldInfo> fieldInfos { get; set; }
        public object description { get; set; }
        public bool showAttachments { get; set; }
        public List<object> mediaInfos { get; set; }
    }

    public class DrawingInfo
    {
        public Renderer renderer { get; set; }
        public bool fixedSymbols { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string alias { get; set; }
        public string type { get; set; }
        public bool editable { get; set; }
        public bool nullable { get; set; }
        public object domain { get; set; }
        public int? length { get; set; }
    }

    public class Extent
    {
        public double xmin { get; set; }
        public double ymin { get; set; }
        public double xmax { get; set; }
        public double ymax { get; set; }
        public SpatialReference spatialReference { get; set; }
    }

    public class DefaultSymbol
    {
        public int angle { get; set; }
        public int xoffset { get; set; }
        public int yoffset { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public double width { get; set; }
        public double height { get; set; }
    }

    public class Symbol
    {
        public int angle { get; set; }
        public int xoffset { get; set; }
        public int yoffset { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public double width { get; set; }
        public double height { get; set; }
    }

    public class UniqueValueInfo
    {
        public string value { get; set; }
        public Symbol symbol { get; set; }
        public string label { get; set; }
    }

    public class Renderer
    {
        public string type { get; set; }
        public string field1 { get; set; }
        public DefaultSymbol defaultSymbol { get; set; }
        public string defaultLabel { get; set; }
        public List<UniqueValueInfo> uniqueValueInfos { get; set; }
    }

    public class SpatialReference
    {
        public int wkid { get; set; }
    }

    public class SpatialReference2
    {
        public int wkid { get; set; }
    }

    public class SpatialReference3
    {
        public int wkid { get; set; }
        public int? latestWkid { get; set; }
    }

    public class Geometry
    {
        public double x { get; set; }
        public double y { get; set; }
        public SpatialReference3 spatialReference { get; set; }
    }

    public class Attributes
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string OwnerContactInfo { get; set; }
        public string Url { get; set; }
        public string UrlMyGRMS { get; set; }
        public string Access { get; set; }
        public string Notes { get; set; }
        public string RX_Frequency { get; set; }
        public string RX_Tone { get; set; }
        public string TX_Frequency { get; set; }
        public string TX_Tone { get; set; }
        public string W_N { get; set; }
        public string Power { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public int __OBJECTID { get; set; }
        public string OwnerCallsign { get; set; }
    }

    public class Feature
    {
        public Geometry geometry { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Format
    {
        public int places { get; set; }
        public bool digitSeparator { get; set; }
    }

    public class FieldInfo
    {
        public string fieldName { get; set; }
        public string label { get; set; }
        public bool isEditable { get; set; }
        public string tooltip { get; set; }
        public bool visible { get; set; }
        public Format format { get; set; }
        public string stringFieldOption { get; set; }
    }
}
