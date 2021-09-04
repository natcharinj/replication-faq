#! /bin/bash
yarn
yarn workspaces run dev
dotnet watch run --project ./src/ReplicationFaq.Cms/ReplicationFaq.Cms.csproj