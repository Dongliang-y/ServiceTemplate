基于实际项目情况，Dto对象使用 CodeSmith脚本初始化，生成的文件名为 *.Designer.cs,减少开发了，便于落地。

DTO封装的是数据传输对象,有时候充当VO。
|----VO 用于UI呈现的 ViewModel。  
|----Commands 是用于执行  CUD 操作的命令对象,他其实也算是数据传输对象的一种。
|----Querys 是用于封装查询对象。