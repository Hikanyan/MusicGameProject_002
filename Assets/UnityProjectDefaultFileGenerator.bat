@echo off
chcp 65001

:: スクリプトを実行した場所を取得します
set "location=%~dp0"

:: プロジェクトの構造を定義します
set "project=Project"
set "folders=%project%\Audio %project%\GameData %project%\Models %project%\Prefab\System %project%\Prefab\UI %project%\Prefab\Data %project%\Scenes\Debug %project%\Scenes\Main %project%\Scripts\Core %project%\Scripts\InGamePlay %project%\Scripts\OutGamePlay %project%\UI"

:: プロジェクトのルートフォルダを作成します
mkdir "%location%%project%"

:: サブフォルダを作成します
for %%f in (%folders%) do (
    mkdir "%location%%%f"
)

echo ファイル構造の作成が完了しました！
pause
