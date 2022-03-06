namespace NiTiS.Core.Systems;

public interface IPreInitSystem
{
    public void PreInit();
}
public interface IPreInitSystem<ARG>
{
    public void PreInit(ARG arg);
}
public interface IPreInitSystem<ARG1, ARG2>
{
    public void PreInit(ARG1 arg1, ARG2 arg2);
}
public interface IPreInitSystem<ARG1, ARG2, ARG3>
{
    public void PreInit(ARG1 arg1, ARG2 arg2, ARG3 arg3);
}
public interface IPreInitSystem<ARG1, ARG2, ARG3, ARG4>
{
    public void PreInit(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4);
}
public interface IPreInitSystem<ARG1, ARG2, ARG3, ARG4, ARG5>
{
    public void PreInit(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5);
}
public interface IPreInitSystem<ARG1, ARG2, ARG3, ARG4, ARG5, ARG6>
{
    public void PreInit(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5, ARG6 arg6);
}