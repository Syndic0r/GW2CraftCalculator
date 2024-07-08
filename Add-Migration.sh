#!/bin/bash

dotnet ef migrations add $1 --startup-project GW2CraftCalculator --project GW2CraftCalculator.Data