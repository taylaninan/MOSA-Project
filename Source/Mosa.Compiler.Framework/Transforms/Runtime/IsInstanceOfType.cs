// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.Runtime;

/// <summary>
/// IsInstanceOfType
/// </summary>
public sealed class IsInstanceOfType : BaseRuntimeTransform
{
	public IsInstanceOfType() : base(IRInstruction.IsInstanceOfType, TransformType.Manual | TransformType.Transform)
	{
	}

	public override int Priority => -10;

	public override bool Match(Context context, TransformContext transform)
	{
		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		SetVMCall(transform, context, "IsInstanceOfType", context.Result, context.GetOperands());
	}
}
