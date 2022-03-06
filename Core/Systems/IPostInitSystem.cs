namespace NiTiS.Core.Systems;

public interface IPostInitSystem
{
    public void PostInit();
}
public interface IPostInitSystem<ARG>
{
    public void PostInit(ARG arg);
}
public interface IPostInitSystem<ARG1, ARG2>
{
    public void PostInit(ARG1 arg1, ARG2 arg2);
}
public interface IPostInitSystem<ARG1, ARG2, ARG3>
{
    public void PostInit(ARG1 arg1, ARG2 arg2, ARG3 arg3);
}
public interface IPostInitSystem<ARG1, ARG2, ARG3, ARG4>
{
    public void PostInit(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4);
}
public interface IPostInitSystem<ARG1, ARG2, ARG3, ARG4, ARG5>
{
    public void PostInit(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5);
}
public interface IPostInitSystem<ARG1, ARG2, ARG3, ARG4, ARG5, ARG6>
{
    public void PostInit(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5, ARG6 arg6);
}