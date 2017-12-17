# 组成部件

* 过滤
  * 状态单选过滤
  * 单据信息过滤
    * 编号过滤
    * 日期过滤
    * 更多下拉
* 分类显示的数据表格
  * 单选/多选择框列
* 分页控件
* 确定选择按钮


# 开发步骤

* 写出From语句`string`
* 布置过滤条件
* 实现GetFilter方法
* 设计表格列

# SQL生成过程

1. orderBy = GetOrderBy()
2. where = GetFilter()
3. id(s) = select id into #tmp from `from` where `where` order by `orderby`
4. paging = getPaign()
5. sql = `select` `from` where id in (`id(s)`) order by `orderby`


# TODO:

* 查询操作与生成语句操作分离
* 自主选择列、排序、过滤条件