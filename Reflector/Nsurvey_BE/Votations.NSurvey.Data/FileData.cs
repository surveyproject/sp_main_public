﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2300
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Votations.NSurvey.Data {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class FileData : DataSet {
        
        private FilesDataTable tableFiles;
        
        public FileData() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected FileData(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(XmlTextReader.Create(new System.IO.StringReader(strSchema), new XmlReaderSettings() { DtdProcessing = DtdProcessing.Ignore, XmlResolver = null }));
                if ((ds.Tables["Files"] != null)) {
                    this.Tables.Add(new FilesDataTable(ds.Tables["Files"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public FilesDataTable Files {
            get {
                return this.tableFiles;
            }
        }
        
        public override DataSet Clone() {
            FileData cln = ((FileData)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["Files"] != null)) {
                this.Tables.Add(new FilesDataTable(ds.Tables["Files"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            //return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
            return System.Xml.Schema.XmlSchema.Read((XmlTextReader.Create(stream, new XmlReaderSettings() { DtdProcessing = DtdProcessing.Ignore, XmlResolver = null })), null);
        }
        
        internal void InitVars() {
            this.tableFiles = ((FilesDataTable)(this.Tables["Files"]));
            if ((this.tableFiles != null)) {
                this.tableFiles.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "FileData";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/FileData.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableFiles = new FilesDataTable();
            this.Tables.Add(this.tableFiles);
        }
        
        private bool ShouldSerializeFiles() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void FilesRowChangeEventHandler(object sender, FilesRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class FilesDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnFileId;
            
            private DataColumn columnGroupGuid;
            
            private DataColumn columnFileName;
            
            private DataColumn columnFileSize;
            
            private DataColumn columnFileType;
            
            private DataColumn columnSaveDate;
            
            private DataColumn columnVoterId;
            
            internal FilesDataTable() : 
                    base("Files") {
                this.InitClass();
            }
            
            internal FilesDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn FileIdColumn {
                get {
                    return this.columnFileId;
                }
            }
            
            internal DataColumn GroupGuidColumn {
                get {
                    return this.columnGroupGuid;
                }
            }
            
            internal DataColumn FileNameColumn {
                get {
                    return this.columnFileName;
                }
            }
            
            internal DataColumn FileSizeColumn {
                get {
                    return this.columnFileSize;
                }
            }
            
            internal DataColumn FileTypeColumn {
                get {
                    return this.columnFileType;
                }
            }
            
            internal DataColumn SaveDateColumn {
                get {
                    return this.columnSaveDate;
                }
            }
            
            internal DataColumn VoterIdColumn {
                get {
                    return this.columnVoterId;
                }
            }
            
            public FilesRow this[int index] {
                get {
                    return ((FilesRow)(this.Rows[index]));
                }
            }
            
            public event FilesRowChangeEventHandler FilesRowChanged;
            
            public event FilesRowChangeEventHandler FilesRowChanging;
            
            public event FilesRowChangeEventHandler FilesRowDeleted;
            
            public event FilesRowChangeEventHandler FilesRowDeleting;
            
            public void AddFilesRow(FilesRow row) {
                this.Rows.Add(row);
            }
            
            public FilesRow AddFilesRow(string GroupGuid, string FileName, int FileSize, string FileType, System.DateTime SaveDate, int VoterId) {
                FilesRow rowFilesRow = ((FilesRow)(this.NewRow()));
                rowFilesRow.ItemArray = new object[] {
                        null,
                        GroupGuid,
                        FileName,
                        FileSize,
                        FileType,
                        SaveDate,
                        VoterId};
                this.Rows.Add(rowFilesRow);
                return rowFilesRow;
            }
            
            public FilesRow FindByFileIdGroupGuidVoterId(int FileId, string GroupGuid, int VoterId) {
                return ((FilesRow)(this.Rows.Find(new object[] {
                            FileId,
                            GroupGuid,
                            VoterId})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                FilesDataTable cln = ((FilesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new FilesDataTable();
            }
            
            internal void InitVars() {
                this.columnFileId = this.Columns["FileId"];
                this.columnGroupGuid = this.Columns["GroupGuid"];
                this.columnFileName = this.Columns["FileName"];
                this.columnFileSize = this.Columns["FileSize"];
                this.columnFileType = this.Columns["FileType"];
                this.columnSaveDate = this.Columns["SaveDate"];
                this.columnVoterId = this.Columns["VoterId"];
            }
            
            private void InitClass() {
                this.columnFileId = new DataColumn("FileId", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnFileId);
                this.columnGroupGuid = new DataColumn("GroupGuid", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnGroupGuid);
                this.columnFileName = new DataColumn("FileName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnFileName);
                this.columnFileSize = new DataColumn("FileSize", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnFileSize);
                this.columnFileType = new DataColumn("FileType", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnFileType);
                this.columnSaveDate = new DataColumn("SaveDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnSaveDate);
                this.columnVoterId = new DataColumn("VoterId", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnVoterId);
                this.Constraints.Add(new UniqueConstraint("FileDataKey1", new DataColumn[] {
                                this.columnFileId,
                                this.columnGroupGuid,
                                this.columnVoterId}, true));
                this.columnFileId.AutoIncrement = true;
                this.columnFileId.AllowDBNull = false;
                this.columnFileId.ReadOnly = true;
                this.columnGroupGuid.AllowDBNull = false;
                this.columnFileName.AllowDBNull = false;
                this.columnVoterId.AllowDBNull = false;
            }
            
            public FilesRow NewFilesRow() {
                return ((FilesRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new FilesRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(FilesRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.FilesRowChanged != null)) {
                    this.FilesRowChanged(this, new FilesRowChangeEvent(((FilesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.FilesRowChanging != null)) {
                    this.FilesRowChanging(this, new FilesRowChangeEvent(((FilesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.FilesRowDeleted != null)) {
                    this.FilesRowDeleted(this, new FilesRowChangeEvent(((FilesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.FilesRowDeleting != null)) {
                    this.FilesRowDeleting(this, new FilesRowChangeEvent(((FilesRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveFilesRow(FilesRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class FilesRow : DataRow {
            
            private FilesDataTable tableFiles;
            
            internal FilesRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableFiles = ((FilesDataTable)(this.Table));
            }
            
            public int FileId {
                get {
                    return ((int)(this[this.tableFiles.FileIdColumn]));
                }
                set {
                    this[this.tableFiles.FileIdColumn] = value;
                }
            }
            
            public string GroupGuid {
                get {
                    return ((string)(this[this.tableFiles.GroupGuidColumn]));
                }
                set {
                    this[this.tableFiles.GroupGuidColumn] = value;
                }
            }
            
            public string FileName {
                get {
                    return ((string)(this[this.tableFiles.FileNameColumn]));
                }
                set {
                    this[this.tableFiles.FileNameColumn] = value;
                }
            }
            
            public int FileSize {
                get {
                    try {
                        return ((int)(this[this.tableFiles.FileSizeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableFiles.FileSizeColumn] = value;
                }
            }
            
            public string FileType {
                get {
                    if (this.IsFileTypeNull()) {
                        return null;
                    }
                    else {
                        return ((string)(this[this.tableFiles.FileTypeColumn]));
                    }
                }
                set {
                    this[this.tableFiles.FileTypeColumn] = value;
                }
            }
            
            public System.DateTime SaveDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.tableFiles.SaveDateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableFiles.SaveDateColumn] = value;
                }
            }
            
            public int VoterId {
                get {
                    return ((int)(this[this.tableFiles.VoterIdColumn]));
                }
                set {
                    this[this.tableFiles.VoterIdColumn] = value;
                }
            }
            
            public bool IsFileSizeNull() {
                return this.IsNull(this.tableFiles.FileSizeColumn);
            }
            
            public void SetFileSizeNull() {
                this[this.tableFiles.FileSizeColumn] = System.Convert.DBNull;
            }
            
            public bool IsFileTypeNull() {
                return this.IsNull(this.tableFiles.FileTypeColumn);
            }
            
            public void SetFileTypeNull() {
                this[this.tableFiles.FileTypeColumn] = System.Convert.DBNull;
            }
            
            public bool IsSaveDateNull() {
                return this.IsNull(this.tableFiles.SaveDateColumn);
            }
            
            public void SetSaveDateNull() {
                this[this.tableFiles.SaveDateColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class FilesRowChangeEvent : EventArgs {
            
            private FilesRow eventRow;
            
            private DataRowAction eventAction;
            
            public FilesRowChangeEvent(FilesRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public FilesRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
