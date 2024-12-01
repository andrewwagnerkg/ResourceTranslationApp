using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTranslationTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Locales_LocaleId",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Resources_ResourceId",
                table: "Translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translation",
                table: "Translation");

            migrationBuilder.RenameTable(
                name: "Translation",
                newName: "Translations");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_ResourceId",
                table: "Translations",
                newName: "IX_Translations_ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translations",
                table: "Translations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Locales_LocaleId",
                table: "Translations",
                column: "LocaleId",
                principalTable: "Locales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Resources_ResourceId",
                table: "Translations",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Locales_LocaleId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Resources_ResourceId",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translations",
                table: "Translations");

            migrationBuilder.RenameTable(
                name: "Translations",
                newName: "Translation");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_ResourceId",
                table: "Translation",
                newName: "IX_Translation_ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translation",
                table: "Translation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Locales_LocaleId",
                table: "Translation",
                column: "LocaleId",
                principalTable: "Locales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Resources_ResourceId",
                table: "Translation",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
