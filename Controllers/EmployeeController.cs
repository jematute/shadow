using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

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
        var field = Expression.Constant("Custom");

        Expression[] expressions = new Expression[] { em, field };

        Type[] args = new Type[] { typeof(string) };

    //     var method = typeof(EF)
    // .GetMethods()
    // .Single(m => m.Name == "Property" && m.GetParameters().Count() == 2)
    // .MakeGenericMethod(new[] {typeof(EF)});

        var ex = Expression.Call(typeof(EF), "Property", args, expressions);

        var con = Expression.Constant("2345");

        var ex2 = Expression.Call(ex, typeof(string).GetMethod("Equals", new[] { typeof(string) }), con);

        Expression<Func<Employee, bool>> deleg = Expression.Lambda<Func<Employee, bool>>(ex2, em);

        var query = sql.Employees.Where(deleg);

        var select = query.Select(t => new { Hello = EF.Property<string>(t, "Custom")});


        //var linq = query.Select("Custom").ToDynamicList();
        
        var emps = query.ToList();

        ParameterExpression entity = Expression.Parameter(typeof(Employee), "entity");

        var efLikeMethod = typeof(DbFunctionsExtensions).GetMethod("Like",
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
            null,
            new[] { typeof(DbFunctions), typeof(string), typeof(string) },
            null);
        var pattern = Expression.Constant($"%2%", typeof(string));

        var property = Expression.Property(entity, "FirstName");

        Expression expr = Expression.Call(efLikeMethod,
                    Expression.Property(null, typeof(EF), nameof(EF.Functions)), ex, pattern);

        Expression<Func<Employee, bool>> deleg2 = Expression.Lambda<Func<Employee, bool>>(expr, em);

        var ff = sql.Employees.Where(deleg2).ToList();
        
        var s = sql.Employees.Where(t => EF.Functions.Like(EF.Property<string>(t, "Custom"), "%2%")).ToList();

        //var t = Expression.Call(null, efLikeMethod, new Expression[] { ex, con });
        


        Expression[] expressions2 = new Expression[] { ex, con };

        // var expcall = Expression.Call(param, );

        var query2 = sql.Employees.Where(s => EF.Functions.Like(EF.Property<string>(s, "Custom"), "1234")).ToList();



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
