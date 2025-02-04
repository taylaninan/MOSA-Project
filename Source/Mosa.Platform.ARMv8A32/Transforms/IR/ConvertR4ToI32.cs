// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Transforms.IR;

/// <summary>
/// ConvertR4ToI32
/// </summary>
[Transform("ARMv8A32.IR")]
public sealed class ConvertR4ToI32 : BaseIRTransform
{
	public ConvertR4ToI32() : base(IRInstruction.ConvertR4ToI32, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		Translate(transform, context, ARMv8A32.Fix, true);
	}
}
