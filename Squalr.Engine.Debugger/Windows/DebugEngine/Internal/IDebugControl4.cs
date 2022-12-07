﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Text;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace Microsoft.Diagnostics.Runtime.Interop
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("94e60ce9-9b41-4b19-9fc0-6d9eb35272b3")]
    public interface IDebugControl4 : IDebugControl3
    {
        /* IDebugControl */

        [PreserveSig]
        new Int32 GetInterrupt();

        [PreserveSig]
        new Int32 SetInterrupt(
            [In] DEBUG_INTERRUPT Flags);

        [PreserveSig]
        new Int32 GetInterruptTimeout(
            [Out] out UInt32 Seconds);

        [PreserveSig]
        new Int32 SetInterruptTimeout(
            [In] UInt32 Seconds);

        [PreserveSig]
        new Int32 GetLogFile(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out Boolean Append);

        [PreserveSig]
        new Int32 OpenLogFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] Boolean Append);

        [PreserveSig]
        new Int32 CloseLogFile();

        [PreserveSig]
        new Int32 GetLogMask(
            [Out] out DEBUG_OUTPUT Mask);

        [PreserveSig]
        new Int32 SetLogMask(
            [In] DEBUG_OUTPUT Mask);

        [PreserveSig]
        new Int32 Input(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 InputSize);

        [PreserveSig]
        new Int32 ReturnInput(
            [In, MarshalAs(UnmanagedType.LPStr)] string Buffer);

        [PreserveSig]
        new Int32 Output(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        new Int32 OutputVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        new Int32 ControlledOutput(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        new Int32 ControlledOutputVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        new Int32 OutputPrompt(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        [PreserveSig]
        new Int32 OutputPromptVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        new Int32 GetPromptText(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 TextSize);

        [PreserveSig]
        new Int32 OutputCurrentState(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_CURRENT Flags);

        [PreserveSig]
        new Int32 OutputVersionInformation(
            [In] DEBUG_OUTCTL OutputControl);

        [PreserveSig]
        new Int32 GetNotifyEventHandle(
            [Out] out UInt64 Handle);

        [PreserveSig]
        new Int32 SetNotifyEventHandle(
            [In] UInt64 Handle);

        [PreserveSig]
        new Int32 Assemble(
            [In] UInt64 Offset,
            [In, MarshalAs(UnmanagedType.LPStr)] string Instr,
            [Out] out UInt64 EndOffset);

        [PreserveSig]
        new Int32 Disassemble(
            [In] UInt64 Offset,
            [In] DEBUG_DISASM Flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 DisassemblySize,
            [Out] out UInt64 EndOffset);

        [PreserveSig]
        new Int32 GetDisassembleEffectiveOffset(
            [Out] out UInt64 Offset);

        [PreserveSig]
        new Int32 OutputDisassembly(
            [In] DEBUG_OUTCTL OutputControl,
            [In] UInt64 Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out UInt64 EndOffset);

        [PreserveSig]
        new Int32 OutputDisassemblyLines(
            [In] DEBUG_OUTCTL OutputControl,
            [In] UInt32 PreviousLines,
            [In] UInt32 TotalLines,
            [In] UInt64 Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out UInt32 OffsetLine,
            [Out] out UInt64 StartOffset,
            [Out] out UInt64 EndOffset,
            [Out, MarshalAs(UnmanagedType.LPArray)] UInt64[] LineOffsets);

        [PreserveSig]
        new Int32 GetNearInstruction(
            [In] UInt64 Offset,
            [In] Int32 Delta,
            [Out] out UInt64 NearOffset);

        [PreserveSig]
        new Int32 GetStackTrace(
            [In] UInt64 FrameOffset,
            [In] UInt64 StackOffset,
            [In] UInt64 InstructionOffset,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] Int32 FrameSize,
            [Out] out UInt32 FramesFilled);

        [PreserveSig]
        new Int32 GetReturnOffset(
            [Out] out UInt64 Offset);

        [PreserveSig]
        new Int32 OutputStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] Int32 FramesSize,
            [In] DEBUG_STACK Flags);

        [PreserveSig]
        new Int32 GetDebuggeeType(
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);

        [PreserveSig]
        new Int32 GetActualProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new Int32 GetExecutingProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new Int32 GetNumberPossibleExecutingProcessorTypes(
            [Out] out UInt32 Number);

        [PreserveSig]
        new Int32 GetPossibleExecutingProcessorTypes(
            [In] UInt32 Start,
            [In] UInt32 Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] IMAGE_FILE_MACHINE[] Types);

        [PreserveSig]
        new Int32 GetNumberProcessors(
            [Out] out UInt32 Number);

        [PreserveSig]
        new Int32 GetSystemVersion(
            [Out] out UInt32 PlatformId,
            [Out] out UInt32 Major,
            [Out] out UInt32 Minor,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ServicePackString,
            [In] Int32 ServicePackStringSize,
            [Out] out UInt32 ServicePackStringUsed,
            [Out] out UInt32 ServicePackNumber,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder BuildString,
            [In] Int32 BuildStringSize,
            [Out] out UInt32 BuildStringUsed);

        [PreserveSig]
        new Int32 GetPageSize(
            [Out] out UInt32 Size);

        [PreserveSig]
        new Int32 IsPointer64Bit();

        [PreserveSig]
        new Int32 ReadBugCheckData(
            [Out] out UInt32 Code,
            [Out] out UInt64 Arg1,
            [Out] out UInt64 Arg2,
            [Out] out UInt64 Arg3,
            [Out] out UInt64 Arg4);

        [PreserveSig]
        new Int32 GetNumberSupportedProcessorTypes(
            [Out] out UInt32 Number);

        [PreserveSig]
        new Int32 GetSupportedProcessorTypes(
            [In] UInt32 Start,
            [In] UInt32 Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] IMAGE_FILE_MACHINE[] Types);

        [PreserveSig]
        new Int32 GetProcessorTypeNames(
            [In] IMAGE_FILE_MACHINE Type,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] Int32 FullNameBufferSize,
            [Out] out UInt32 FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] Int32 AbbrevNameBufferSize,
            [Out] out UInt32 AbbrevNameSize);

        [PreserveSig]
        new Int32 GetEffectiveProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new Int32 SetEffectiveProcessorType(
            [In] IMAGE_FILE_MACHINE Type);

        [PreserveSig]
        new Int32 GetExecutionStatus(
            [Out] out DEBUG_STATUS Status);

        [PreserveSig]
        new Int32 SetExecutionStatus(
            [In] DEBUG_STATUS Status);

        [PreserveSig]
        new Int32 GetCodeLevel(
            [Out] out DEBUG_LEVEL Level);

        [PreserveSig]
        new Int32 SetCodeLevel(
            [In] DEBUG_LEVEL Level);

        [PreserveSig]
        new Int32 GetEngineOptions(
            [Out] out DEBUG_ENGOPT Options);

        [PreserveSig]
        new Int32 AddEngineOptions(
            [In] DEBUG_ENGOPT Options);

        [PreserveSig]
        new Int32 RemoveEngineOptions(
            [In] DEBUG_ENGOPT Options);

        [PreserveSig]
        new Int32 SetEngineOptions(
            [In] DEBUG_ENGOPT Options);

        [PreserveSig]
        new Int32 GetSystemErrorControl(
            [Out] out ERROR_LEVEL OutputLevel,
            [Out] out ERROR_LEVEL BreakLevel);

        [PreserveSig]
        new Int32 SetSystemErrorControl(
            [In] ERROR_LEVEL OutputLevel,
            [In] ERROR_LEVEL BreakLevel);

        [PreserveSig]
        new Int32 GetTextMacro(
            [In] UInt32 Slot,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 MacroSize);

        [PreserveSig]
        new Int32 SetTextMacro(
            [In] UInt32 Slot,
            [In, MarshalAs(UnmanagedType.LPStr)] string Macro);

        [PreserveSig]
        new Int32 GetRadix(
            [Out] out UInt32 Radix);

        [PreserveSig]
        new Int32 SetRadix(
            [In] UInt32 Radix);

        [PreserveSig]
        new Int32 Evaluate(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out UInt32 RemainderIndex);

        [PreserveSig]
        new Int32 CoerceValue(
            [In] DEBUG_VALUE In,
            [In] DEBUG_VALUE_TYPE OutType,
            [Out] out DEBUG_VALUE Out);

        [PreserveSig]
        new Int32 CoerceValues(
            [In] UInt32 Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] In,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE_TYPE[] OutType,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Out);

        [PreserveSig]
        new Int32 Execute(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        new Int32 ExecuteCommandFile(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        new Int32 GetNumberBreakpoints(
            [Out] out UInt32 Number);

        [PreserveSig]
        new Int32 GetBreakpointByIndex(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint bp);

        [PreserveSig]
        new Int32 GetBreakpointById(
            [In] UInt32 Id,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint bp);

        [PreserveSig]
        new Int32 GetBreakpointParameters(
            [In] UInt32 Count,
            [In, MarshalAs(UnmanagedType.LPArray)] UInt32[] Ids,
            [In] UInt32 Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_BREAKPOINT_PARAMETERS[] Params);

        [PreserveSig]
        new Int32 AddBreakpoint(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] UInt32 DesiredId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint Bp);

        [PreserveSig]
        new Int32 RemoveBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugBreakpoint Bp);

        [PreserveSig]
        new Int32 AddExtension(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [In] UInt32 Flags,
            [Out] out UInt64 Handle);

        [PreserveSig]
        new Int32 RemoveExtension(
            [In] UInt64 Handle);

        [PreserveSig]
        new Int32 GetExtensionByPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path,
            [Out] out UInt64 Handle);

        [PreserveSig]
        new Int32 CallExtension(
            [In] UInt64 Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPStr)] string Arguments);

        [PreserveSig]
        new Int32 GetExtensionFunction(
            [In] UInt64 Handle,
            [In, MarshalAs(UnmanagedType.LPStr)] string FuncName,
            [Out] out IntPtr Function);

        [PreserveSig]
        new Int32 GetWindbgExtensionApis32(
            [In, Out] ref WINDBG_EXTENSION_APIS Api);

        /* Must be In and Out as the nSize member has to be initialized */

        [PreserveSig]
        new Int32 GetWindbgExtensionApis64(
            [In, Out] ref WINDBG_EXTENSION_APIS Api);

        /* Must be In and Out as the nSize member has to be initialized */

        [PreserveSig]
        new Int32 GetNumberEventFilters(
            [Out] out UInt32 SpecificEvents,
            [Out] out UInt32 SpecificExceptions,
            [Out] out UInt32 ArbitraryExceptions);

        [PreserveSig]
        new Int32 GetEventFilterText(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 TextSize);

        [PreserveSig]
        new Int32 GetEventFilterCommand(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 CommandSize);

        [PreserveSig]
        new Int32 SetEventFilterCommand(
            [In] UInt32 Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        [PreserveSig]
        new Int32 GetSpecificFilterParameters(
            [In] UInt32 Start,
            [In] UInt32 Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);

        [PreserveSig]
        new Int32 SetSpecificFilterParameters(
            [In] UInt32 Start,
            [In] UInt32 Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);

        [PreserveSig]
        new Int32 GetSpecificEventFilterArgument(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 ArgumentSize);

        [PreserveSig]
        new Int32 SetSpecificEventFilterArgument(
            [In] UInt32 Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Argument);

        [PreserveSig]
        new Int32 GetExceptionFilterParameters(
            [In] UInt32 Count,
            [In, MarshalAs(UnmanagedType.LPArray)] UInt32[] Codes,
            [In] UInt32 Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        [PreserveSig]
        new Int32 SetExceptionFilterParameters(
            [In] UInt32 Count,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        [PreserveSig]
        new Int32 GetExceptionFilterSecondCommand(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 CommandSize);

        [PreserveSig]
        new Int32 SetExceptionFilterSecondCommand(
            [In] UInt32 Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        [PreserveSig]
        new Int32 WaitForEvent(
            [In] DEBUG_WAIT Flags,
            [In] UInt32 Timeout);

        [PreserveSig]
        new Int32 GetLastEventInformation(
            [Out] out DEBUG_EVENT Type,
            [Out] out UInt32 ProcessId,
            [Out] out UInt32 ThreadId,
            [In] IntPtr ExtraInformation,
            [In] UInt32 ExtraInformationSize,
            [Out] out UInt32 ExtraInformationUsed,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] Int32 DescriptionSize,
            [Out] out UInt32 DescriptionUsed);

        /* IDebugControl2 */

        [PreserveSig]
        new Int32 GetCurrentTimeDate(
            [Out] out UInt32 TimeDate);

        [PreserveSig]
        new Int32 GetCurrentSystemUpTime(
            [Out] out UInt32 UpTime);

        [PreserveSig]
        new Int32 GetDumpFormatFlags(
            [Out] out DEBUG_FORMAT FormatFlags);

        [PreserveSig]
        new Int32 GetNumberTextReplacements(
            [Out] out UInt32 NumRepl);

        [PreserveSig]
        new Int32 GetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder SrcBuffer,
            [In] Int32 SrcBufferSize,
            [Out] out UInt32 SrcSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder DstBuffer,
            [In] Int32 DstBufferSize,
            [Out] out UInt32 DstSize);

        [PreserveSig]
        new Int32 SetTextReplacement(
            [In, MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPStr)] string DstText);

        [PreserveSig]
        new Int32 RemoveTextReplacements();

        [PreserveSig]
        new Int32 OutputTextReplacements(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUT_TEXT_REPL Flags);

        /* IDebugControl3 */

        [PreserveSig]
        new Int32 GetAssemblyOptions(
            [Out] out DEBUG_ASMOPT Options);

        [PreserveSig]
        new Int32 AddAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        new Int32 RemoveAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        new Int32 SetAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        [PreserveSig]
        new Int32 GetExpressionSyntax(
            [Out] out DEBUG_EXPR Flags);

        [PreserveSig]
        new Int32 SetExpressionSyntax(
            [In] DEBUG_EXPR Flags);

        [PreserveSig]
        new Int32 SetExpressionSyntaxByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string AbbrevName);

        [PreserveSig]
        new Int32 GetNumberExpressionSyntaxes(
            [Out] out UInt32 Number);

        [PreserveSig]
        new Int32 GetExpressionSyntaxNames(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] Int32 FullNameBufferSize,
            [Out] out UInt32 FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] Int32 AbbrevNameBufferSize,
            [Out] out UInt32 AbbrevNameSize);

        [PreserveSig]
        new Int32 GetNumberEvents(
            [Out] out UInt32 Events);

        [PreserveSig]
        new Int32 GetEventIndexDescription(
            [In] UInt32 Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 DescSize);

        [PreserveSig]
        new Int32 GetCurrentEventIndex(
            [Out] out UInt32 Index);

        [PreserveSig]
        new Int32 SetNextEventIndex(
            [In] DEBUG_EINDEX Relation,
            [In] UInt32 Value,
            [Out] out UInt32 NextIndex);

        /* IDebugControl4 */

        [PreserveSig]
        Int32 GetLogFileWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 FileSize,
            [Out, MarshalAs(UnmanagedType.Bool)] out Boolean Append);

        [PreserveSig]
        Int32 OpenLogFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In, MarshalAs(UnmanagedType.Bool)] Boolean Append);

        [PreserveSig]
        Int32 InputWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 InputSize);

        [PreserveSig]
        Int32 ReturnInputWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Buffer);

        [PreserveSig]
        Int32 OutputWide(
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);

        [PreserveSig]
        Int32 OutputVaListWide( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        Int32 ControlledOutputWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);

        [PreserveSig]
        Int32 ControlledOutputVaListWide( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        Int32 OutputPromptWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);

        [PreserveSig]
        Int32 OutputPromptVaListWide( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        [PreserveSig]
        Int32 GetPromptTextWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 TextSize);

        [PreserveSig]
        Int32 AssembleWide(
            [In] UInt64 Offset,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Instr,
            [Out] out UInt64 EndOffset);

        [PreserveSig]
        Int32 DisassembleWide(
            [In] UInt64 Offset,
            [In] DEBUG_DISASM Flags,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 DisassemblySize,
            [Out] out UInt64 EndOffset);

        [PreserveSig]
        Int32 GetProcessorTypeNamesWide(
            [In] IMAGE_FILE_MACHINE Type,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer,
            [In] Int32 FullNameBufferSize,
            [Out] out UInt32 FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer,
            [In] Int32 AbbrevNameBufferSize,
            [Out] out UInt32 AbbrevNameSize);

        [PreserveSig]
        Int32 GetTextMacroWide(
            [In] UInt32 Slot,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 MacroSize);

        [PreserveSig]
        Int32 SetTextMacroWide(
            [In] UInt32 Slot,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Macro);

        [PreserveSig]
        Int32 EvaluateWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out UInt32 RemainderIndex);

        [PreserveSig]
        Int32 ExecuteWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        Int32 ExecuteCommandFileWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        [PreserveSig]
        Int32 GetBreakpointByIndex2(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint2 bp);

        [PreserveSig]
        Int32 GetBreakpointById2(
            [In] UInt32 Id,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint2 bp);

        [PreserveSig]
        Int32 AddBreakpoint2(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] UInt32 DesiredId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugBreakpoint2 Bp);

        [PreserveSig]
        Int32 RemoveBreakpoint2(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugBreakpoint2 Bp);

        [PreserveSig]
        Int32 AddExtensionWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [In] UInt32 Flags,
            [Out] out UInt64 Handle);

        [PreserveSig]
        Int32 GetExtensionByPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path,
            [Out] out UInt64 Handle);

        [PreserveSig]
        Int32 CallExtensionWide(
            [In] UInt64 Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Function,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Arguments);

        [PreserveSig]
        Int32 GetExtensionFunctionWide(
            [In] UInt64 Handle,
            [In, MarshalAs(UnmanagedType.LPWStr)] string FuncName,
            [Out] out IntPtr Function);

        [PreserveSig]
        Int32 GetEventFilterTextWide(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 TextSize);

        [PreserveSig]
        Int32 GetEventFilterCommandWide(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 CommandSize);

        [PreserveSig]
        Int32 SetEventFilterCommandWide(
            [In] UInt32 Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);

        [PreserveSig]
        Int32 GetSpecificEventFilterArgumentWide(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 ArgumentSize);

        [PreserveSig]
        Int32 SetSpecificEventFilterArgumentWide(
            [In] UInt32 Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Argument);

        [PreserveSig]
        Int32 GetExceptionFilterSecondCommandWide(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 CommandSize);

        [PreserveSig]
        Int32 SetExceptionFilterSecondCommandWide(
            [In] UInt32 Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);

        [PreserveSig]
        Int32 GetLastEventInformationWide(
            [Out] out DEBUG_EVENT Type,
            [Out] out UInt32 ProcessId,
            [Out] out UInt32 ThreadId,
            [In] IntPtr ExtraInformation,
            [In] Int32 ExtraInformationSize,
            [Out] out UInt32 ExtraInformationUsed,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Description,
            [In] Int32 DescriptionSize,
            [Out] out UInt32 DescriptionUsed);

        [PreserveSig]
        Int32 GetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder SrcBuffer,
            [In] Int32 SrcBufferSize,
            [Out] out UInt32 SrcSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder DstBuffer,
            [In] Int32 DstBufferSize,
            [Out] out UInt32 DstSize);

        [PreserveSig]
        Int32 SetTextReplacementWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In, MarshalAs(UnmanagedType.LPWStr)] string DstText);

        [PreserveSig]
        Int32 SetExpressionSyntaxByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string AbbrevName);

        [PreserveSig]
        Int32 GetExpressionSyntaxNamesWide(
            [In] UInt32 Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FullNameBuffer,
            [In] Int32 FullNameBufferSize,
            [Out] out UInt32 FullNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder AbbrevNameBuffer,
            [In] Int32 AbbrevNameBufferSize,
            [Out] out UInt32 AbbrevNameSize);

        [PreserveSig]
        Int32 GetEventIndexDescriptionWide(
            [In] UInt32 Index,
            [In] DEBUG_EINDEX Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 DescSize);

        [PreserveSig]
        Int32 GetLogFile2(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 FileSize,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        Int32 OpenLogFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        Int32 GetLogFile2Wide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 FileSize,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        Int32 OpenLogFile2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out DEBUG_LOG Flags);

        [PreserveSig]
        Int32 GetSystemVersionValues(
            [Out] out UInt32 PlatformId,
            [Out] out UInt32 Win32Major,
            [Out] out UInt32 Win32Minor,
            [Out] out UInt32 KdMajor,
            [Out] out UInt32 KdMinor);

        [PreserveSig]
        Int32 GetSystemVersionString(
            [In] DEBUG_SYSVERSTR Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 StringSize);

        [PreserveSig]
        Int32 GetSystemVersionStringWide(
            [In] DEBUG_SYSVERSTR Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] Int32 BufferSize,
            [Out] out UInt32 StringSize);

        [PreserveSig]
        Int32 GetContextStackTrace(
            [In] IntPtr StartContext,
            [In] UInt32 StartContextSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] Int32 FrameSize,
            [In] IntPtr FrameContexts,
            [In] UInt32 FrameContextsSize,
            [In] UInt32 FrameContextsEntrySize,
            [Out] out UInt32 FramesFilled);

        [PreserveSig]
        Int32 OutputContextStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPArray)] DEBUG_STACK_FRAME[] Frames,
            [In] Int32 FramesSize,
            [In] IntPtr FrameContexts,
            [In] UInt32 FrameContextsSize,
            [In] UInt32 FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);

        [PreserveSig]
        Int32 GetStoredEventInformation(
            [Out] out DEBUG_EVENT Type,
            [Out] out UInt32 ProcessId,
            [Out] out UInt32 ThreadId,
            [In] IntPtr Context,
            [In] UInt32 ContextSize,
            [Out] out UInt32 ContextUsed,
            [In] IntPtr ExtraInformation,
            [In] UInt32 ExtraInformationSize,
            [Out] out UInt32 ExtraInformationUsed);

        [PreserveSig]
        Int32 GetManagedStatus(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder String,
            [In] Int32 StringSize,
            [Out] out UInt32 StringNeeded);

        [PreserveSig]
        Int32 GetManagedStatusWide(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder String,
            [In] Int32 StringSize,
            [Out] out UInt32 StringNeeded);

        [PreserveSig]
        Int32 ResetManagedStatus(
            [In] DEBUG_MANRESET Flags);
    }
    //// End interface
}
//// End namespace