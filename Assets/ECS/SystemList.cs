
using System.Collections.Generic;


namespace ecs
{

	public static class SystemList
	{
		public static List<EntitySystem> systemList = new List<EntitySystem>()
		{
			new MyTransformSystem(typeof(MyTransform)),
			new MyRenderSystem(typeof(MyTransform), typeof(MyRender)),

			new TestSys1(typeof(MyTransform), typeof(TestCom1)),
			new TestSys2(typeof(MyTransform), typeof(TestCom2)),
			new TestSys3(typeof(MyTransform), typeof(TestCom3)),
			new TestSys4(typeof(MyTransform), typeof(TestCom4)),
			new TestSys5(typeof(MyTransform), typeof(TestCom5)),
			new TestSys6(typeof(MyTransform), typeof(TestCom6)),
			new TestSys7(typeof(MyTransform), typeof(TestCom7)),
			new TestSys8(typeof(MyTransform), typeof(TestCom8)),
			new TestSys9(typeof(MyTransform), typeof(TestCom9)),

			new TestSys10(typeof(MyTransform), typeof(TestCom3)),
			new TestSys11(typeof(MyTransform), typeof(TestCom3)),
			new TestSys12(typeof(MyTransform), typeof(TestCom3)),
			new TestSys13(typeof(MyTransform), typeof(TestCom3)),
			new TestSys14(typeof(MyTransform), typeof(TestCom3)),
			new TestSys15(typeof(MyTransform), typeof(TestCom3)),
			new TestSys16(typeof(MyTransform), typeof(TestCom3)),
			new TestSys17(typeof(MyTransform), typeof(TestCom3)),
			new TestSys18(typeof(MyTransform), typeof(TestCom3)),
			new TestSys19(typeof(MyTransform), typeof(TestCom3)),
			new TestSys20(typeof(MyTransform), typeof(TestCom3)),
			new TestSys21(typeof(MyTransform), typeof(TestCom3)),
			new TestSys22(typeof(MyTransform), typeof(TestCom3)),
			new TestSys23(typeof(MyTransform), typeof(TestCom3)),
			new TestSys24(typeof(MyTransform), typeof(TestCom3)),
			new TestSys25(typeof(MyTransform), typeof(TestCom3)),
			new TestSys26(typeof(MyTransform), typeof(TestCom3)),
			new TestSys27(typeof(MyTransform), typeof(TestCom3)),
			new TestSys28(typeof(MyTransform), typeof(TestCom3)),
			new TestSys29(typeof(MyTransform), typeof(TestCom3)),
			new TestSys30(typeof(MyTransform), typeof(TestCom3)),
			new TestSys31(typeof(MyTransform), typeof(TestCom3)),
			new TestSys32(typeof(MyTransform), typeof(TestCom3)),
			new TestSys33(typeof(MyTransform), typeof(TestCom3)),


			new TestSysAll(typeof(MyTransform), 
				typeof(TestCom41), typeof(TestCom42), typeof(TestCom3), typeof(TestCom4), typeof(TestCom5),
				typeof(TestCom6), typeof(TestCom7), typeof(TestCom8), typeof(TestCom9), typeof(TestCom10),
				typeof(TestCom11), typeof(TestCom12), typeof(TestCom13), typeof(TestCom14), typeof(TestCom15),
				typeof(TestCom16), typeof(TestCom17), typeof(TestCom18), typeof(TestCom19), typeof(TestCom20),
				typeof(TestCom21), typeof(TestCom22), typeof(TestCom23), typeof(TestCom24), typeof(TestCom25),
				typeof(TestCom26), typeof(TestCom27), typeof(TestCom28), typeof(TestCom29), typeof(TestCom30),
				typeof(TestCom31), typeof(TestCom32), typeof(TestCom33), typeof(TestCom34), typeof(TestCom35)
				),
		};
	}

}