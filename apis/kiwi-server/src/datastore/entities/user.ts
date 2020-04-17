import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class User {
  @PrimaryGeneratedColumn()
  id: number;

  @Column({ length: 150 })
  password: string;

  @Column({ length: 50 })
  username: string;

  @Column({ length: 50 })
  email: string;

  @Column({ type: 'date', default: () => new Date()})
  createdAt: Date;

  @Column({ type: 'date', default: () => new Date()})
  updatedAt: Date;

  @Column({ default: true })
  active: boolean;
}