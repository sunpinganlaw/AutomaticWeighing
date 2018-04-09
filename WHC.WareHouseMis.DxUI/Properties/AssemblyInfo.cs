using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("WareHouseMis")]
[assembly: AssemblyDescription("备件仓库管理系统，备件信息管理、备件入库、备件出库、库存查询、库房管理、业务报表、权限管理、数据字典管理、备件及库存导入等功能，是一款优秀易用的仓库管理软件。")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("广州爱奇迪软件科技有限公司")]
[assembly: AssemblyProduct("备件仓库管理系统")]
[assembly: AssemblyCopyright("Copyright © iqidi 2013")]
[assembly: AssemblyTrademark("深田之星系列软件")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("c60ed4af-74bf-40db-b444-736c0832a3d7")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“内部版本号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("3.0.0.0")]
[assembly: AssemblyFileVersion("3.0.0.0")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4net.config", Watch = true)]