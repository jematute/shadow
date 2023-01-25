using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace shadow.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{

    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetEmployees")]
    public IActionResult Get()
    {
        SQLiteContext sql = new SQLiteContext();

        var em = Expression.Parameter(typeof(Employee), "t");
        var str = Expression.Constant("Custom");

        Expression[] expressions = new Expression[] { em, str };

        Type[] args = new Type[] { typeof(string) };

    //     var method = typeof(EF)
    // .GetMethods()
    // .Single(m => m.Name == "Property" && m.GetParameters().Count() == 2)
    // .MakeGenericMethod(new[] {typeof(EF)});

        var ex = Expression.Call(typeof(EF), "Property", args, expressions);

        var con = Expression.Constant("2345");



        var ex2 = Expression.Call(ex, typeof(string).GetMethod("Equals", new[] { typeof(string) }), con);

        Expression<Func<Employee, bool>> deleg = Expression.Lambda<Func<Employee, bool>>(ex2, em);

        var emps = sql.Employees.Where(deleg).ToList();


        // var expcall = Expression.Call(param, );

        //var query = sql.Employees.Where(s => EF.Property<string>(s, "Custom").StartsWith("1234"));

        // var query2 = sql.Employees.Where(s => s.City.Equals("Northampton"));

        // var exp2 = query2.Expression;

        // var emps = query.Select(s => EF.Property<string>(s, "Custom")).ToList();


        

        return Ok(emps);
    }

    private IQueryable<T> CreateExpression<T>(IQueryable<T> query, string field) {
        Expression queryExp = null;

        var param = Expression.Parameter(typeof(T), "f");

        // Expression.Call()

        return query;
    }

    [HttpPost(Name = "AddEmployee")]
    public IActionResult Add([FromBody] Employee employee)
    {
        SQLiteContext sql = new SQLiteContext();

        var emps = sql.Add(employee);

        sql.SaveChanges();

        return Ok();
    }
}
