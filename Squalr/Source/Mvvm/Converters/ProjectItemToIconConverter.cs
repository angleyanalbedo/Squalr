﻿namespace Squalr.Source.Mvvm.Converters
{
    using Squalr.Content;
    using Squalr.Engine.Projects;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Converts ProjectItems to an icon format readily usable by the view.
    /// </summary>
    public class ProjectItemToIconConverter : IValueConverter
    {
        /// <summary>
        /// Converts an Icon to a BitmapSource.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="targetType">Type to convert to.</param>
        /// <param name="parameter">Optional conversion parameter.</param>
        /// <param name="culture">Globalization info.</param>
        /// <returns>Object with type of BitmapSource. If conversion cannot take place, returns null.</returns>
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                value = parameter;
            }

            switch (value)
            {
                case ProjectItem type when type is PointerItem:
                    return Images.LetterP;
                case ProjectItem type when type is ScriptItem:
                    return Images.Script;
                default:
                    return Images.CollectValues;
            }
        }

        /// <summary>
        /// Not used or implemented.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="targetType">Type to convert to.</param>
        /// <param name="parameter">Optional conversion parameter.</param>
        /// <param name="culture">Globalization info.</param>
        /// <returns>Throws see <see cref="NotImplementedException" />.</returns>
        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    //// End class
}
//// End namespace