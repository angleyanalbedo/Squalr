﻿namespace Squalr.Source.Controls
{
    using Squalr.Engine.Common.Extensions;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// An attribute for property viewer visible properties that should be sorted into specific categories.
    /// </summary>
    public class SortedCategory : CategoryAttribute
    {
        private const Char NonPrintableChar = '\t';

        /// <summary>
        /// Defines category types for items displayed in the property viewer.
        /// </summary>
        public enum CategoryType
        {
            /// <summary>
            /// Defines the common category type, used for properties commonly changed by users.
            /// </summary>
            [Description("Common")]
            Common = 1,

            /// <summary>
            /// Defines the advanced category type, used for properties changed by advanced users.
            /// </summary>
            [Description("Advanced")]
            Advanced = 2,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortedCategory" /> class.
        /// </summary>
        /// <param name="category">The category type used to sort the property.</param>
        public SortedCategory(CategoryType category)
            : base(category.GetDescription().PadLeft(category.GetDescription().Length + Enum.GetNames(typeof(CategoryType)).Length - (Int32)category, SortedCategory.NonPrintableChar))
        {
        }
    }
    //// End class
}
//// End namespace