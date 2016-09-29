# dapper-demo

### A Sample Code Generate Template

AutoGenerate entities and basic methods of accessing database using [T4 template](https://msdn.microsoft.com/en-us/library/bb126445.aspx "T4 template").

database access methods based on [dapper-dot-net](https://github.com/StackExchange/dapper-dot-net "dapper-dot-net").

#### objects and its generate objects

<table>
<tr>
<td></td>
<td>C</td>
<td>R</td>
<td>U</td>
<td>D</td>
</tr>
<tr>
    <td>view</td>
    <td>F</td>
    <td>T</td>
    <td>F</td>
    <td>F</td>
</tr>
<tr>
    <td>table with primary key or auto increase</td>
    <td>T</td>
    <td>T</td>
    <td>T</td>
    <td>T</td>
</tr>
<tr>
    <td>table without primary key and auto increase</td>
    <td>T</td>
    <td>T</td>
    <td>F</td>
    <td>F</td>
</tr>
</table>


if you wanna run the tests, execute the sql file in the folder of this sln.And replace the the connection string in T4 template file and the app.config file in test prj.
