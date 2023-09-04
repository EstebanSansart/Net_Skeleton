namespace API.Helpers;
public class Authorization
{
    public enum Roles
    {
        Admin,
        Gerente,
        Empleado
    }
    public const Roles default_role = Roles.Empleado;
}