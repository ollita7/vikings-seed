import {MigrationInterface, QueryRunner} from "typeorm";

export class addActiveToUser1587680253918 implements MigrationInterface {

    public async up(queryRunner: QueryRunner): Promise<any> {
      await queryRunner.query(`ALTER TABLE "user" ADD COLUMN "active" boolean DEFAULT true;`);
    }

    public async down(queryRunner: QueryRunner): Promise<any> {
    }

}
