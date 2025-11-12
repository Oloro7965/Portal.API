#!/bin/bash
set -e
set +H  # evita erro com "!" na senha

echo "⏳ Aguardando SQL Server iniciar..."

# Aguarda até 120s para o SQL Server responder
for i in {1..40}; do
  if /opt/mssql-tools18/bin/sqlcmd \
    -S "tcp:portaldb,1433" \
    -U sa -P 'YourStrongPassw0rd' \
    -N -C -Q "SELECT 1" &>/dev/null; then
    echo "✅ SQL Server disponível!"
    break
  fi
  echo "🕓 Tentando conexão... ($i/40)"
  sleep 3
done

if [ $i -eq 40 ]; then
  echo "❌ Falha: SQL Server não respondeu após 120s."
  exit 1
fi

# Executa a aplicação
echo "🚀 Iniciando Portal.API..."
exec dotnet /app/publish/Portal.API.dll
