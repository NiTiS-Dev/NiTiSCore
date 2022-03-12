cd Core
cd NiTiS
dotnet build -c Release -o ../../.build/
dotnet pack -c Release -o ../../.build/

cd ..
dotnet pack NiTiS.IO/ -c Release -o ../.build/
dotnet pack NiTiS.Collections/ -c Release -o ../.build/
dotnet pack NiTiS.Interaction/ -c Release -o ../.build/
dotnet pack NiTiS.Math/ -c Release -o ../.build/
dotnet pack NiTiS.Reflection/ -c Release -o ../.build/
dotnet pack NiTiS.Additions/ -c Release -o ../.build/

cd ..