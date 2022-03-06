namespace NiTiS.Core.Systems;

public interface IInitSystem
{
    public void Init();
}
public interface IInitSystem<ARG>
{
    public void Init(ARG arg);
}
public interface IInitSystem<ARG1, ARG2>
{
    public void Init(ARG1 arg1, ARG2 arg2);
}
public interface IInitSystem<ARG1, ARG2, ARG3>
{
    public void Init(ARG1 arg1, ARG2 arg2, ARG3 arg3);
}
public interface IInitSystem<ARG1, ARG2, ARG3, ARG4>
{
    public void Init(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4);
}
public interface IInitSystem<ARG1, ARG2, ARG3, ARG4, ARG5>
{
    public void Init(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5);
}
public interface IInitSystem<ARG1, ARG2, ARG3, ARG4, ARG5, ARG6>
{
    public void Init(ARG1 arg1, ARG2 arg2, ARG3 arg3, ARG4 arg4, ARG5 arg5, ARG6 arg6);
}