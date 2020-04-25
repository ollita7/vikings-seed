import {MigrationInterface, QueryRunner} from "typeorm";

export class addTokenToUser1587683895890 implements MigrationInterface {

    public async up(queryRunner: QueryRunner): Promise<any> {
      await queryRunner.query(`ALTER TABLE "user" ADD COLUMN token character varying(150);`);
    }

    public async down(queryRunner: QueryRunner): Promise<any> {
      await queryRunner.query(`ALTER TABLE "user" DROP token`);
    }

}
