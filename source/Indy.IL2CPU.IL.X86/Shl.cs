using System;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using CPU = Indy.IL2CPU.Assembler.X86;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(Code.Shl)]
	public class Shl: Op {
		public Shl(Mono.Cecil.Cil.Instruction aInstruction, MethodInformation aMethodInfo)
			: base(aInstruction, aMethodInfo) {
		}
		public override void DoAssemble() {
			int xSize = Assembler.StackSizes.Peek();
			Pop("eax"); // shift amount
			Pop("edx"); // value
			Move(Assembler, "ebx", "0");
			Move(Assembler, "cl", "al");
			Assembler.Add(new CPU.ShiftLeft("edx", "ebx", "cl"));
			Pushd(xSize, "edx");
		}
	}
}