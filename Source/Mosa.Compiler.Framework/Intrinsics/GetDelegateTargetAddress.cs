﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Intrinsics;

/// <summary>
/// IntrinsicMethods
/// </summary>
internal static partial class IntrinsicMethods
{
	[IntrinsicMethod("Mosa.Runtime.Intrinsic::GetDelegateTargetAddress")]
	private static void GetDelegateTargetAddress(Context context, TransformContext transformContext)
	{
		context.SetInstruction(transformContext.LoadInstruction, context.Result, context.Operand1, Operand.CreateConstant32(transformContext.Architecture.NativePointerSize));
	}
}
