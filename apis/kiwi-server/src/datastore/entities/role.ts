import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class Role {
  @PrimaryGeneratedColumn()
  id: number;

  @Column({ length: 150 })
  name: string;

  @Column({ type: 'date', default: () => new Date()})
  createdAt: Date;

  @Column({ type: 'date', default: () => new Date()})
  updatedAt: Date;
}
