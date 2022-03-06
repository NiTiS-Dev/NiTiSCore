namespace NiTiS.Core.Systems;

public interface IUpdateSystem
{
    public void Update();
}
public interface IUpdateSystem<ARG>
{
    public void Update(ARG arg);
}
public interface IUpdateSystem<ARG1, ARG2>
{
    public void Update(ARG1 arg1, ARG2 arg2);
}
public interface IUpdateSystem<ARG1, ARG2, ARG3>
{
    public void Update(ARG1 arg1, ARG2 arg2, ARG3 arg3);
}
public interface IUpdateSystem<ARG1, ARG2, ARG3, ARG4>
{
    public void Update(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4);
}
public interface IUpdateSystem<ARG1, ARG2, ARG3, ARG4, ARG5>
{
    public void Update(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5);
}
public interface IUpdateSystem<ARG1, ARG2, ARG3, ARG4, ARG5, ARG6>
{
    public void Update(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5, ARG6 arg6);
}