#!/bin/bash
dotnet publish GW2CraftCalculator -r win-x64 -p:PublishSingleFile=True --self-contained false -o "Release"