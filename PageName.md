# Introduction #

我的毕业设计-基于RBAC权限模型的设计与实现
本工程使用ASP.NET MVC2+SQL SERER 2008



# Details #

工程主要分成一下几层：
UI层
BLL层
DAO层
ENTITY层

UI层使用的是ASP.NET MVC2。
ENTITY是数据库表的映射，这里我是按照“约定优于配置”的思想，entity里的所有类必须和数据库表里的一致，这样就可以省去映射的过程。
在使用DAO层的时候先继承BaseDao<Entity类>，基本的CURD操作都不用自己写只要传递进去entity就可以了。DAO层使用了一个SQLHelper类，用户和数据库的连接，在web.config里配置connection string指定的名称是SQLServer，要改的去SQL帮助类改吧。