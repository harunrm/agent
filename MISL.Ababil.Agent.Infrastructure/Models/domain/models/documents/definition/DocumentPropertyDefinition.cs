using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents.definition
{
    public class DocumentPropertyDefinition
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string name { get; set; }
        public DocPropertyDataType dataType { get; set; }
        public string regexFormat { get; set; }
        public Boolean isMandatory { get; set; }
        public Boolean isUnique { get; set; }
        public List<string> possibleValues { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public long refernaceNumber { get; set; }

        //public long getId() {
        //    return id;
        //}

        //public void setId(long id) {
        //    this.id = id;
        //}

        //public string getName() {
        //    return name;
        //}

        //public void setName(string name) {
        //    this.name = name;
        //}

        //public DocPropertyDataType getDataType() {
        //    return dataType;
        //}

        //public void setDataType(DocPropertyDataType dataType) {
        //    this.dataType = dataType;
        //}

        //public string getRegexFormat() {
        //    return regexFormat;
        //}

        //public void setRegexFormat(string regexFormat) {
        //    this.regexFormat = regexFormat;
        //}

        //public Boolean getIsMandatory() {
        //    return isMandatory;
        //}

        //public void setIsMandatory(Boolean isMandatory) {
        //    this.isMandatory = isMandatory;
        //}

        //public Boolean getIsUnique() {
        //    return isUnique;
        //}

        //public void setIsUnique(Boolean isUnique) {
        //    this.isUnique = isUnique;
        //}

        //public List<string> getPossibleValues() {
        //    return possibleValues;
        //}

        //public void setPossibleValues(List<string> possibleValues) {
        //    this.possibleValues = possibleValues;
        //}

        //public int getMinLength() {
        //    return minLength;
        //}

        //public void setMinLength(int minLength) {
        //    this.minLength = minLength;
        //}

        //public int getMaxLength() {
        //    return maxLength;
        //}

        //public void setMaxLength(int maxLength) {
        //    this.maxLength = maxLength;
        //}

        //public long getRefernaceNumber() {
        //    return refernaceNumber;
        //}

        //public void setRefernaceNumber(long refernaceNumber) {
        //    this.refernaceNumber = refernaceNumber;
        //}
    }
}
