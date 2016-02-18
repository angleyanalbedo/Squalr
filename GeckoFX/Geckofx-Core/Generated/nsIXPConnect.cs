// --------------------------------------------------------------------------------------------
// Version: MPL 1.1/GPL 2.0/LGPL 2.1
// 
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
// 
// <remarks>
// Generated by IDLImporter from file nsIXPConnect.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using System.Runtime.CompilerServices;
	
	
	/// <summary> </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("909e8641-7c54-4dff-9b94-ba631f057b33")]
	public interface nsIXPConnectJSObjectHolder
	{
		
		/// <summary> </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetJSObject();
	}
	
	/// <summary>nsIXPConnectWrappedNative </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("675b01ba-397b-472a-9b80-5716376a2ec6")]
	public interface nsIXPConnectWrappedNative : nsIXPConnectJSObjectHolder
	{
		
		/// <summary> </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new System.IntPtr GetJSObject();
		
		/// <summary>
        ///attribute 'JSObject' inherited from nsIXPConnectJSObjectHolder </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsISupports GetNativeAttribute();
		
		/// <summary>Member GetJSObjectPrototypeAttribute </summary>
		/// <returns>A System.IntPtr</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetJSObjectPrototypeAttribute();
		
		/// <summary>
        /// These are here as an aid to nsIXPCScriptable implementors
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIInterfaceInfo FindInterfaceWithMember(ref System.IntPtr nameID);
		
		/// <summary>Member FindInterfaceWithName </summary>
		/// <param name='nameID'> </param>
		/// <returns>A nsIInterfaceInfo</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIInterfaceInfo FindInterfaceWithName(ref System.IntPtr nameID);
		
		/// <summary>Member HasNativeMember </summary>
		/// <param name='name'> </param>
		/// <returns>A System.Boolean</returns>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool HasNativeMember(ref System.IntPtr name);
		
		/// <summary>Member DebugDump </summary>
		/// <param name='depth'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DebugDump(short depth);
		
		/// <summary>
        /// This finishes initializing a wrapped global, doing the parts that we
        /// couldn't do while the global and window were being simultaneously
        /// bootstrapped. This should be called exactly once, and only for wrapped
        /// globals.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void FinishInitForWrappedGlobal();
	}
	
	/// <summary>
    /// NOTE: Add new IDL methods _before_ the C++ block below if you
    /// add them.  Otherwise the vtable won't be what xpidl thinks it
    /// is, since GetObjectPrincipal() is virtual.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("BED52030-BCA6-11d2-BA79-00805F8A5DD7")]
	public interface nsIXPConnectWrappedJS : nsIXPConnectJSObjectHolder
	{
		
		/// <summary> </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new System.IntPtr GetJSObject();
		
		/// <summary>
        ///attribute 'JSObject' inherited from nsIXPConnectJSObjectHolder </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIInterfaceInfo GetInterfaceInfoAttribute();
		
		System.Guid GetInterfaceIIDAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DebugDump(short depth);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr AggregatedQueryInterface(ref System.Guid uuid);
	}
	
	/// <summary>
    /// This is a sort of a placeholder interface. It is not intended to be
    /// implemented. It exists to give the nsIXPCSecurityManager an iid on
    /// which to gate a specific activity in XPConnect.
    ///
    /// That activity is...
    ///
    /// When JavaScript code uses a component that is itself implemented in
    /// JavaScript then XPConnect will build a wrapper rather than directly
    /// expose the JSObject of the component. This allows components implemented
    /// in JavaScript to 'look' just like any other xpcom component (from the
    /// perspective of the JavaScript caller). This insulates the component from
    /// the caller and hides any properties or methods that are not part of the
    /// interface as declared in xpidl. Usually this is a good thing.
    ///
    /// However, in some cases it is useful to allow the JS caller access to the
    /// JS component's underlying implementation. In order to facilitate this
    /// XPConnect supports the 'wrappedJSObject' property. The caller code can do:
    ///
    /// // 'foo' is some xpcom component (that might be implemented in JS).
    /// try {
    /// var bar = foo.wrappedJSObject;
    /// if(bar) {
    /// // bar is the underlying JSObject. Do stuff with it here.
    /// }
    /// } catch(e) {
    /// // security exception?
    /// }
    ///
    /// Recall that 'foo' above is an XPConnect wrapper, not the underlying JS
    /// object. The property get "foo.wrappedJSObject" will only succeed if three
    /// conditions are met:
    ///
    /// 1) 'foo' really is an XPConnect wrapper around a JSObject.
    /// 2) The underlying JSObject actually implements a "wrappedJSObject"
    /// property that returns a JSObject. This is called by XPConnect. This
    /// restriction allows wrapped objects to only allow access to the underlying
    /// JSObject if they choose to do so. Ususally this just means that 'foo'
    /// would have a property tht looks like:
    /// this.wrappedJSObject = this.
    /// 3) The implemementation of nsIXPCSecurityManager (if installed) allows
    /// a property get on the interface below. Although the JSObject need not
    /// implement 'nsIXPCWrappedJSObjectGetter', XPConnect will ask the
    /// security manager if it is OK for the caller to access the only method
    /// in nsIXPCWrappedJSObjectGetter before allowing the activity. This fits
    /// in with the security manager paradigm and makes control over accessing
    /// the property on this interface the control factor for getting the
    /// underlying wrapped JSObject of a JS component from JS code.
    ///
    /// Notes:
    ///
    /// a) If 'foo' above were the underlying JSObject and not a wrapper at all,
    /// then this all just works and XPConnect is not part of the picture at all.
    /// b) One might ask why 'foo' should not just implement an interface through
    /// which callers might get at the underlying object. There are three reasons:
    /// i)   XPConnect would still have to do magic since JSObject is not a
    /// scriptable type.
    /// ii)  JS Components might use aggregation (like C++ objects) and have
    /// different JSObjects for different interfaces 'within' an aggregate
    /// object. But, using an additional interface only allows returning one
    /// underlying JSObject. However, this allows for the possibility that
    /// each of the aggregte JSObjects could return something different.
    /// Note that one might do: this.wrappedJSObject = someOtherObject;
    /// iii) Avoiding the explicit interface makes it easier for both the caller
    /// and the component.
    ///
    /// Anyway, some future implementation of nsIXPCSecurityManager might want
    /// do special processing on 'nsIXPCSecurityManager::CanGetProperty' when
    /// the interface id is that of nsIXPCWrappedJSObjectGetter.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("254bb2e0-6439-11d4-8fe0-0010a4e73d9a")]
	public interface nsIXPCWrappedJSObjectGetter
	{
		
		/// <summary>
        /// This is a sort of a placeholder interface. It is not intended to be
        /// implemented. It exists to give the nsIXPCSecurityManager an iid on
        /// which to gate a specific activity in XPConnect.
        ///
        /// That activity is...
        ///
        /// When JavaScript code uses a component that is itself implemented in
        /// JavaScript then XPConnect will build a wrapper rather than directly
        /// expose the JSObject of the component. This allows components implemented
        /// in JavaScript to 'look' just like any other xpcom component (from the
        /// perspective of the JavaScript caller). This insulates the component from
        /// the caller and hides any properties or methods that are not part of the
        /// interface as declared in xpidl. Usually this is a good thing.
        ///
        /// However, in some cases it is useful to allow the JS caller access to the
        /// JS component's underlying implementation. In order to facilitate this
        /// XPConnect supports the 'wrappedJSObject' property. The caller code can do:
        ///
        /// // 'foo' is some xpcom component (that might be implemented in JS).
        /// try {
        /// var bar = foo.wrappedJSObject;
        /// if(bar) {
        /// // bar is the underlying JSObject. Do stuff with it here.
        /// }
        /// } catch(e) {
        /// // security exception?
        /// }
        ///
        /// Recall that 'foo' above is an XPConnect wrapper, not the underlying JS
        /// object. The property get "foo.wrappedJSObject" will only succeed if three
        /// conditions are met:
        ///
        /// 1) 'foo' really is an XPConnect wrapper around a JSObject.
        /// 2) The underlying JSObject actually implements a "wrappedJSObject"
        /// property that returns a JSObject. This is called by XPConnect. This
        /// restriction allows wrapped objects to only allow access to the underlying
        /// JSObject if they choose to do so. Ususally this just means that 'foo'
        /// would have a property tht looks like:
        /// this.wrappedJSObject = this.
        /// 3) The implemementation of nsIXPCSecurityManager (if installed) allows
        /// a property get on the interface below. Although the JSObject need not
        /// implement 'nsIXPCWrappedJSObjectGetter', XPConnect will ask the
        /// security manager if it is OK for the caller to access the only method
        /// in nsIXPCWrappedJSObjectGetter before allowing the activity. This fits
        /// in with the security manager paradigm and makes control over accessing
        /// the property on this interface the control factor for getting the
        /// underlying wrapped JSObject of a JS component from JS code.
        ///
        /// Notes:
        ///
        /// a) If 'foo' above were the underlying JSObject and not a wrapper at all,
        /// then this all just works and XPConnect is not part of the picture at all.
        /// b) One might ask why 'foo' should not just implement an interface through
        /// which callers might get at the underlying object. There are three reasons:
        /// i)   XPConnect would still have to do magic since JSObject is not a
        /// scriptable type.
        /// ii)  JS Components might use aggregation (like C++ objects) and have
        /// different JSObjects for different interfaces 'within' an aggregate
        /// object. But, using an additional interface only allows returning one
        /// underlying JSObject. However, this allows for the possibility that
        /// each of the aggregte JSObjects could return something different.
        /// Note that one might do: this.wrappedJSObject = someOtherObject;
        /// iii) Avoiding the explicit interface makes it easier for both the caller
        /// and the component.
        ///
        /// Anyway, some future implementation of nsIXPCSecurityManager might want
        /// do special processing on 'nsIXPCSecurityManager::CanGetProperty' when
        /// the interface id is that of nsIXPCWrappedJSObjectGetter.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsISupports GetNeverCalledAttribute();
	}
	
	/// <summary>
    /// This interface is implemented by outside code and registered with xpconnect
    /// via nsIXPConnect::setFunctionThisTranslator.
    ///
    /// The reason this exists is to support calls to JavaScript event callbacks
    /// needed by the DOM via xpconnect from C++ code.
    ///
    /// We've added support for wrapping JS function objects as xpcom interfaces
    /// by declaring the given interface as a [function] interface. However, to
    /// support the requirements of JS event callbacks we need to call the JS
    /// function with the 'this' set as the JSObject for which the event is being
    /// fired; e.g. a form node.
    ///
    /// We've decided that for all cases we care about the appropriate 'this' object
    /// can be derived from the first param in the call to the callback. In the
    /// event handler case the first param is an event object.
    ///
    /// Though we can't change all the JS code so that it would setup its own 'this',
    /// we can add plugin 'helper' support to xpconnect. And that is what we have
    /// here.
    ///
    /// The idea is that at startup time some code that cares about this issue
    /// (e.g. the DOM helper code) can register a nsIXPCFunctionThisTranslator
    /// object with xpconnect to handle calls to [function] interfaces of a given
    /// iid. When xpconnect goes to invoke a method on a wrapped JSObject for
    /// an interface marked as [function], xpconnect will check if the first param
    /// of the method is an xpcom object pointer and if so it will check to see if a
    /// nsIXPCFunctionThisTranslator has been registered for the given iid of the
    /// interface being called. If so it will call the translator and get an
    /// interface pointer to use as the 'this' for the call. If the translator
    /// returns a non-null interface pointer (which it should then have addref'd
    /// since it is being returned as an out param), xpconnect will attempt to build
    /// a wrapper around the pointer and get a JSObject from that wrapper to use
    /// as the 'this' for the call.
    ///
    /// If a null interface pointer is returned then xpconnect will use the default
    /// 'this' - the same JSObject as the function object it is calling.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("f5f84b70-92eb-41f1-a1dd-2eaac0ed564c")]
	public interface nsIXPCFunctionThisTranslator
	{
		
		/// <summary>
        /// This interface is implemented by outside code and registered with xpconnect
        /// via nsIXPConnect::setFunctionThisTranslator.
        ///
        /// The reason this exists is to support calls to JavaScript event callbacks
        /// needed by the DOM via xpconnect from C++ code.
        ///
        /// We've added support for wrapping JS function objects as xpcom interfaces
        /// by declaring the given interface as a [function] interface. However, to
        /// support the requirements of JS event callbacks we need to call the JS
        /// function with the 'this' set as the JSObject for which the event is being
        /// fired; e.g. a form node.
        ///
        /// We've decided that for all cases we care about the appropriate 'this' object
        /// can be derived from the first param in the call to the callback. In the
        /// event handler case the first param is an event object.
        ///
        /// Though we can't change all the JS code so that it would setup its own 'this',
        /// we can add plugin 'helper' support to xpconnect. And that is what we have
        /// here.
        ///
        /// The idea is that at startup time some code that cares about this issue
        /// (e.g. the DOM helper code) can register a nsIXPCFunctionThisTranslator
        /// object with xpconnect to handle calls to [function] interfaces of a given
        /// iid. When xpconnect goes to invoke a method on a wrapped JSObject for
        /// an interface marked as [function], xpconnect will check if the first param
        /// of the method is an xpcom object pointer and if so it will check to see if a
        /// nsIXPCFunctionThisTranslator has been registered for the given iid of the
        /// interface being called. If so it will call the translator and get an
        /// interface pointer to use as the 'this' for the call. If the translator
        /// returns a non-null interface pointer (which it should then have addref'd
        /// since it is being returned as an out param), xpconnect will attempt to build
        /// a wrapper around the pointer and get a JSObject from that wrapper to use
        /// as the 'this' for the call.
        ///
        /// If a null interface pointer is returned then xpconnect will use the default
        /// 'this' - the same JSObject as the function object it is calling.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsISupports TranslateThis([MarshalAs(UnmanagedType.Interface)] nsISupports aInitialThis);
	}
	
	/// <summary> </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3d5a6320-8764-11e3-baa7-0800200c9a66")]
	public interface nsIXPConnect
	{
		
		/// <summary>
        /// Initializes classes on a global object that has already been created.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void InitClasses(System.IntPtr aJSContext, System.IntPtr aGlobalJSObj);
		
		/// <summary>
        /// Creates a new global object using the given aCOMObj as the global
        /// object. The object will be set up according to the flags (defined
        /// below). If you do not pass INIT_JS_STANDARD_CLASSES, then aCOMObj
        /// must implement nsIXPCScriptable so it can resolve the standard
        /// classes when asked by the JS engine.
        ///
        /// @param aJSContext the context to use while creating the global object.
        /// @param aCOMObj the native object that represents the global object.
        /// @param aPrincipal the principal of the code that will run in this
        /// compartment. Can be null if not on the main thread.
        /// @param aFlags one of the flags below specifying what options this
        /// global object wants.
        /// @param aOptions JSAPI-specific options for the new compartment.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIXPConnectJSObjectHolder InitClassesWithNewWrappedGlobal(System.IntPtr aJSContext, [MarshalAs(UnmanagedType.Interface)] nsISupports aCOMObj, [MarshalAs(UnmanagedType.Interface)] nsIPrincipal aPrincipal, uint aFlags, System.IntPtr aOptions);
		
		/// <summary>
        /// wrapNative will create a new JSObject or return an existing one.
        ///
        /// The JSObject is returned inside a refcounted nsIXPConnectJSObjectHolder.
        /// As long as this holder is held the JSObject will be protected from
        /// collection by JavaScript's garbage collector. It is a good idea to
        /// transfer the JSObject to some equally protected place before releasing
        /// the holder (i.e. use JS_SetProperty to make this object a property of
        /// some other JSObject).
        ///
        /// This method now correctly deals with cases where the passed in xpcom
        /// object already has an associated JSObject for the cases:
        /// 1) The xpcom object has already been wrapped for use in the same scope
        /// as an nsIXPConnectWrappedNative.
        /// 2) The xpcom object is in fact a nsIXPConnectWrappedJS and thus already
        /// has an underlying JSObject.
        ///
        /// It *might* be possible to QueryInterface the nsIXPConnectJSObjectHolder
        /// returned by the method into a nsIXPConnectWrappedNative or a
        /// nsIXPConnectWrappedJS.
        ///
        /// This method will never wrap the JSObject involved in an
        /// XPCNativeWrapper before returning.
        ///
        /// Returns:
        /// success:
        /// NS_OK
        /// failure:
        /// NS_ERROR_XPC_BAD_CONVERT_NATIVE
        /// NS_ERROR_XPC_CANT_GET_JSOBJECT_OF_DOM_OBJECT
        /// NS_ERROR_FAILURE
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIXPConnectJSObjectHolder WrapNative(System.IntPtr aJSContext, System.IntPtr aScope, [MarshalAs(UnmanagedType.Interface)] nsISupports aCOMObj, ref System.Guid aIID);
		
		/// <summary>
        /// Same as wrapNative, but it returns the JSObject in aVal. C++ callers
        /// must ensure that aVal is rooted.
        /// aIID may be null, it means the same as passing in
        /// &NS_GET_IID(nsISupports) but when passing in null certain shortcuts
        /// can be taken because we know without comparing IIDs that the caller is
        /// asking for an nsISupports wrapper.
        /// If aAllowWrapper, then the returned value will be wrapped in the proper
        /// type of security wrapper on top of the XPCWrappedNative (if needed).
        /// This method doesn't push aJSContext on the context stack, so the caller
        /// is required to push it if the top of the context stack is not equal to
        /// aJSContext.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void WrapNativeToJSVal(System.IntPtr aJSContext, System.IntPtr aScope, [MarshalAs(UnmanagedType.Interface)] nsISupports aCOMObj, System.IntPtr aCache, System.Guid aIID, [MarshalAs(UnmanagedType.U1)] bool aAllowWrapper, ref Gecko.MutableJSVal aVal);
		
		/// <summary>
        /// wrapJS will yield a new or previously existing xpcom interface pointer
        /// to represent the JSObject passed in.
        ///
        /// This method now correctly deals with cases where the passed in JSObject
        /// already has an associated xpcom interface for the cases:
        /// 1) The JSObject has already been wrapped as a nsIXPConnectWrappedJS.
        /// 2) The JSObject is in fact a nsIXPConnectWrappedNative and thus already
        /// has an underlying xpcom object.
        /// 3) The JSObject is of a jsclass which supports getting the nsISupports
        /// from the JSObject directly. This is used for idlc style objects
        /// (e.g. DOM objects).
        ///
        /// It *might* be possible to QueryInterface the resulting interface pointer
        /// to nsIXPConnectWrappedJS.
        ///
        /// Returns:
        /// success:
        /// NS_OK
        /// failure:
        /// NS_ERROR_XPC_BAD_CONVERT_JS
        /// NS_ERROR_FAILURE
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr WrapJS(System.IntPtr aJSContext, System.IntPtr aJSObj, ref System.Guid aIID);
		
		/// <summary>
        /// Wraps the given jsval in a nsIVariant and returns the new variant.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIVariant JSValToVariant(System.IntPtr cx, ref Gecko.JsVal aJSVal);
		
		/// <summary>
        /// This only succeeds if the JSObject is a nsIXPConnectWrappedNative.
        /// A new wrapper is *never* constructed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIXPConnectWrappedNative GetWrappedNativeOfJSObject(System.IntPtr aJSContext, System.IntPtr aJSObj);
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsISupports GetNativeOfWrapper(System.IntPtr aJSContext, System.IntPtr aJSObj);
		
		/// <summary>
        /// The security manager to use when the current JSContext has no security
        /// manager.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetDefaultSecurityManager([MarshalAs(UnmanagedType.Interface)] nsIXPCSecurityManager aManager);
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIStackFrame CreateStackFrameLocation(uint aLanguage, [MarshalAs(UnmanagedType.LPStr)] string aFilename, [MarshalAs(UnmanagedType.LPStr)] string aFunctionName, int aLineNumber, [MarshalAs(UnmanagedType.Interface)] nsIStackFrame aCaller);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetCurrentJSContext();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr InitSafeJSContext();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetSafeJSContext();
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIStackFrame GetCurrentJSStackAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetCurrentNativeCallContextAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DebugDump(short depth);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DebugDumpObject([MarshalAs(UnmanagedType.Interface)] nsISupports aCOMObj, short depth);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DebugDumpJSStack([MarshalAs(UnmanagedType.U1)] bool showArgs, [MarshalAs(UnmanagedType.U1)] bool showLocals, [MarshalAs(UnmanagedType.U1)] bool showThisProps);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DebugDumpEvalInJSStackFrame(uint aFrameNumber, [MarshalAs(UnmanagedType.LPStr)] string aSourceText);
		
		/// <summary>
        /// wrapJSAggregatedToNative is just like wrapJS except it is used in cases
        /// where the JSObject is also aggregated to some native xpcom Object.
        /// At present XBL is the only system that might want to do this.
        ///
        /// XXX write more!
        ///
        /// Returns:
        /// success:
        /// NS_OK
        /// failure:
        /// NS_ERROR_XPC_BAD_CONVERT_JS
        /// NS_ERROR_FAILURE
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr WrapJSAggregatedToNative([MarshalAs(UnmanagedType.Interface)] nsISupports aOuter, System.IntPtr aJSContext, System.IntPtr aJSObj, ref System.Guid aIID);
		
		/// <summary>
        /// This only succeeds if the native object is already wrapped by xpconnect.
        /// A new wrapper is *never* constructed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIXPConnectWrappedNative GetWrappedNativeOfNativeObject(System.IntPtr aJSContext, System.IntPtr aScope, [MarshalAs(UnmanagedType.Interface)] nsISupports aCOMObj, ref System.Guid aIID);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetFunctionThisTranslator(ref System.Guid aIID, [MarshalAs(UnmanagedType.Interface)] nsIXPCFunctionThisTranslator aTranslator);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ReparentWrappedNativeIfFound(System.IntPtr aJSContext, System.IntPtr aScope, System.IntPtr aNewParent, [MarshalAs(UnmanagedType.Interface)] nsISupports aCOMObj);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RescueOrphansInScope(System.IntPtr aJSContext, System.IntPtr aScope);
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIXPConnectJSObjectHolder GetWrappedNativePrototype(System.IntPtr aJSContext, System.IntPtr aScope, [MarshalAs(UnmanagedType.Interface)] nsIClassInfo aClassInfo);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal VariantToJS(System.IntPtr ctx, System.IntPtr scope, [MarshalAs(UnmanagedType.Interface)] nsIVariant value);
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIVariant JSToVariant(System.IntPtr ctx, ref Gecko.JsVal value);
		
		/// <summary>
        /// Create a sandbox for evaluating code in isolation using
        /// evalInSandboxObject().
        ///
        /// @param cx A context to use when creating the sandbox object.
        /// @param principal The principal (or NULL to use the null principal)
        /// to use when evaluating code in this sandbox.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIXPConnectJSObjectHolder CreateSandbox(System.IntPtr cx, [MarshalAs(UnmanagedType.Interface)] nsIPrincipal principal);
		
		/// <summary>
        /// Evaluate script in a sandbox, completely isolated from all
        /// other running scripts.
        ///
        /// @param source The source of the script to evaluate.
        /// @param filename The filename of the script. May be null.
        /// @param cx The context to use when setting up the evaluation of
        /// the script. The actual evaluation will happen on a new
        /// temporary context.
        /// @param sandbox The sandbox object to evaluate the script in.
        /// @param returnStringOnly The only results to come out of the
        /// computation (including exceptions) will
        /// be coerced into strings created in the
        /// sandbox.
        /// @return The result of the evaluation as a jsval. If the caller
        /// intends to use the return value from this call the caller
        /// is responsible for rooting the jsval before making a call
        /// to this method.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal EvalInSandboxObject([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase source, [MarshalAs(UnmanagedType.LPStr)] string filename, System.IntPtr cx, System.IntPtr sandbox, [MarshalAs(UnmanagedType.U1)] bool returnStringOnly);
		
		/// <summary>
        /// Whether or not XPConnect should report all JS exceptions when returning
        /// from JS into C++. False by default, although any value set in the
        /// MOZ_REPORT_ALL_JS_EXCEPTIONS environment variable will override the value
        /// passed here.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetReportAllJSExceptions([MarshalAs(UnmanagedType.U1)] bool reportAllJSExceptions);
		
		/// <summary>
        /// Trigger a JS garbage collection.
        /// Use a js::gcreason::Reason from jsfriendapi.h for the kind.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GarbageCollect(uint reason);
		
		/// <summary>
        /// Signals a good place to do an incremental GC slice, because the
        /// browser is drawing a frame.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void NotifyDidPaint();
		
		/// <summary>
        /// Creates a JS object holder around aObject that will hold the object
        /// alive for as long as the holder stays alive.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIXPConnectJSObjectHolder HoldObject(System.IntPtr aJSContext, System.IntPtr aObject);
		
		/// <summary>
        /// When we place the browser in JS debug mode, there can't be any
        /// JS on the stack. This is because we currently activate debugMode
        /// on all scripts in the JSRuntime when the debugger is activated.
        /// This method will turn debug mode on or off when the context
        /// stack reaches zero length.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetDebugModeWhenPossible([MarshalAs(UnmanagedType.U1)] bool mode, [MarshalAs(UnmanagedType.U1)] bool allowSyncDisable);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void WriteScript([MarshalAs(UnmanagedType.Interface)] nsIObjectOutputStream aStream, System.IntPtr aJSContext, System.IntPtr aJSScript);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr ReadScript([MarshalAs(UnmanagedType.Interface)] nsIObjectInputStream aStream, System.IntPtr aJSContext);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void WriteFunction([MarshalAs(UnmanagedType.Interface)] nsIObjectOutputStream aStream, System.IntPtr aJSContext, System.IntPtr aJSObject);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr ReadFunction([MarshalAs(UnmanagedType.Interface)] nsIObjectInputStream aStream, System.IntPtr aJSContext);
		
		/// <summary>
        /// This function should be called in JavaScript error reporters
        /// to signal that they are ignoring the error. In this case,
        /// XPConnect can print a warning to the console.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void MarkErrorUnreported(System.IntPtr aJSContext);
	}
	
	/// <summary>nsIXPConnectConsts </summary>
	public class nsIXPConnectConsts
	{
		
		// 
		public const long INIT_JS_STANDARD_CLASSES = 1<<0;
		
		// 
		public const long DONT_FIRE_ONNEWGLOBALHOOK = 1<<1;
		
		// 
		public const long OMIT_COMPONENTS_OBJECT = 1<<2;
	}
}
