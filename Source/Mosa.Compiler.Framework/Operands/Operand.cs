/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (grover) <sharpos@michaelruck.de>
 */

using System;
using System.Collections.Generic;
using Mosa.Compiler.Metadata;
using Mosa.Compiler.Metadata.Signatures;

namespace Mosa.Compiler.Framework.Operands
{
	/// <summary>
	/// Abstract base class for IR instruction operands.
	/// </summary>
	public abstract class Operand
	{

		#region Data members

		/// <summary>
		/// The namespace of the operand.
		/// </summary>
		protected SigType type;

		/// <summary>
		/// Holds a list of instructions, which define this operand.
		/// </summary>
		private List<int> definitions;

		/// <summary>
		/// Holds a list of instructions, which use this operand.
		/// </summary>
		private List<int> uses;

		#endregion // Data members

		#region Construction

		/// <summary>
		/// Initializes a new instance of <see cref="Operand"/>.
		/// </summary>
		/// <param name="type">The type of the operand.</param>
		protected Operand(SigType type)
		{
			this.type = type;
		}

		#endregion // Construction

		#region Properties

		/// <summary>
		/// Returns a list of instructions, which use this operand.
		/// </summary>
		public List<int> Definitions
		{
			get
			{
				if (definitions == null)
					definitions = new List<int>();

				return definitions;
			}
		}

		/// <summary>
		/// Determines if the operand is a register.
		/// </summary>
		public virtual bool IsRegister { get { return false; } }

		/// <summary>
		/// Determines if the operand is a stack local variable.
		/// </summary>
		public virtual bool IsStackLocal { get { return false; } }

		/// <summary>
		/// Returns the stack type of the operand.
		/// </summary>
		public StackTypeCode StackType { get { return StackTypeFromSigType(type); } }

		/// <summary>
		/// Retrieves the stack type From a sig type.
		/// </summary>
		/// <param name="type">The signature type to convert to a stack type code.</param>
		/// <returns>The equivalent stack type code.</returns>
		public static StackTypeCode StackTypeFromSigType(SigType type)
		{
			StackTypeCode result = StackTypeCode.Unknown;
			switch (type.Type)
			{
				case CilElementType.Void:
					break;

				case CilElementType.Boolean: result = StackTypeCode.Int32; break;
				case CilElementType.Char: result = StackTypeCode.Int32; break;
				case CilElementType.I1: result = StackTypeCode.Int32; break;
				case CilElementType.U1: result = StackTypeCode.Int32; break;
				case CilElementType.I2: result = StackTypeCode.Int32; break;
				case CilElementType.U2: result = StackTypeCode.Int32; break;
				case CilElementType.I4: result = StackTypeCode.Int32; break;
				case CilElementType.U4: result = StackTypeCode.Int32; break;
				case CilElementType.I8: result = StackTypeCode.Int64; break;
				case CilElementType.U8: result = StackTypeCode.Int64; break;
				case CilElementType.R4: result = StackTypeCode.F; break;
				case CilElementType.R8: result = StackTypeCode.F; break;
				case CilElementType.I: result = StackTypeCode.N; break;
				case CilElementType.U: result = StackTypeCode.N; break;
				case CilElementType.Ptr: result = StackTypeCode.Ptr; break;
				case CilElementType.ByRef: result = StackTypeCode.Ptr; break;
				case CilElementType.Object: result = StackTypeCode.O; break;
				case CilElementType.String: result = StackTypeCode.O; break;
				case CilElementType.ValueType: result = StackTypeCode.O; break;
				case CilElementType.Type: result = StackTypeCode.O; break;
				case CilElementType.Class: result = StackTypeCode.O; break;
				case CilElementType.GenericInst: result = StackTypeCode.O; break;
				case CilElementType.Array: result = StackTypeCode.O; break;
				case CilElementType.SZArray: result = StackTypeCode.O; break;
				case CilElementType.Var: result = StackTypeCode.O; break;

				default:
					throw new NotSupportedException(String.Format(@"Can't transform SigType of CilElementType.{0} to StackTypeCode.", type.Type));
			}

			return result;
		}

		/// <summary>
		/// Sigs the type of the type From stack.
		/// </summary>
		/// <param name="typeCode">The type code.</param>
		/// <returns></returns>
		public static SigType SigTypeFromStackType(StackTypeCode typeCode)
		{
			SigType result = null;
			switch (typeCode)
			{
				case StackTypeCode.Int32: result = BuiltInSigType.Int32; break;
				case StackTypeCode.Int64: result = BuiltInSigType.Int64; break;
				case StackTypeCode.F: result = BuiltInSigType.Double; break;
				case StackTypeCode.O: result = BuiltInSigType.Object; break;
				case StackTypeCode.N: result = BuiltInSigType.IntPtr; break;
				default:
					throw new NotSupportedException(@"Can't convert stack type code to SigType.");
			}
			return result;
		}

		/// <summary>
		/// Returns the type of the operand.
		/// </summary>
		public SigType Type { get { return type; } }

		/// <summary>
		/// Returns a list of instructions, which use this operand.
		/// </summary>
		public List<int> Uses
		{
			get
			{
				if (uses == null)
					uses = new List<int>();

				return uses;
			}
		}

		#endregion // Properties

		#region Methods

		/// <summary>
		/// Replaces this operand in all uses and defs with the given operand.
		/// </summary>
		/// <param name="replacement">The replacement operand.</param>
		/// <param name="instructionSet">The instruction set.</param>
		public void Replace(Operand replacement, InstructionSet instructionSet)
		{

			// Iterate all definition sites first
			foreach (int index in Definitions.ToArray())
			{
				Context ctx = new Context(instructionSet, index);

				if (ctx.Result != null)
				{
					// Is this the operand?
					if (ReferenceEquals(ctx.Result, this))
					{
						ctx.Result = replacement;
					}

				}
			}

			// Iterate all use sites
			foreach (int index in Uses.ToArray())
			{
				Context ctx = new Context(instructionSet, index);

				int opIdx = 0;
				foreach (Operand r in ctx.Operands)
				{
					// Is this the operand?
					if (ReferenceEquals(r, this))
					{
						ctx.SetOperand(opIdx, replacement);
					}

					opIdx++;
				}
			}
		}

		#endregion // Methods

		#region Object Overrides

		/// <summary>
		/// Returns a string representation of <see cref="Operand"/>.
		/// </summary>
		/// <returns>A string representation of the operand.</returns>
		public override string ToString()
		{
			return String.Format("[{0}]", type);
		}

		#endregion // Object Overrides

	}
}

