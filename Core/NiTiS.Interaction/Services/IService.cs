using System;

namespace NiTiS.Interaction.Services;

public interface IService
{
	void Initialize(IServiceProvider provider);
	void PostInitialize(IServiceProvider provider);
}
