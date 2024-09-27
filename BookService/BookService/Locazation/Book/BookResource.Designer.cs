﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Locazation.Book {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class BookResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public BookResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infrastructure.Locazation.Book.BookResource", typeof(BookResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نویسنده معتبر وارد کنید.
        /// </summary>
        public static string BookAuthorIdInvalid {
            get {
                return ResourceManager.GetString("BookAuthorIdInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to اطلاعات تکراری است.
        /// </summary>
        public static string BookDuplicate {
            get {
                return ResourceManager.GetString("BookDuplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کتابی پیدا نشد.
        /// </summary>
        public static string BookNoutFoundService {
            get {
                return ResourceManager.GetString("BookNoutFoundService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to سال انتشار صحیح وارد نمایید.
        /// </summary>
        public static string BookPublishYear {
            get {
                return ResourceManager.GetString("BookPublishYear", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to آبجکت عنوان را تعریف کنید.
        /// </summary>
        public static string BookTitleInvalidObject {
            get {
                return ResourceManager.GetString("BookTitleInvalidObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کاراکتر عنوان کتاب باید بیشتر از دو باشد.
        /// </summary>
        public static string BookTitleLength {
            get {
                return ResourceManager.GetString("BookTitleLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عنوان کتاب خالی است.
        /// </summary>
        public static string BookTitleNull {
            get {
                return ResourceManager.GetString("BookTitleNull", resourceCulture);
            }
        }
    }
}
