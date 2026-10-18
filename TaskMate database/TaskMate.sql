CREATE DATABASE IF NOT EXISTS taskmate_db;
USE taskmate_db;

CREATE TABLE usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    rol VARCHAR(50) DEFAULT 'Usuario',
    telefono VARCHAR(20),
    departamento VARCHAR(100),
    estado VARCHAR(20) DEFAULT 'Activo'
);

CREATE TABLE proyectos (
    id_proyecto INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    estado VARCHAR(50) DEFAULT 'Activo',
    progreso INT DEFAULT 0,
    id_responsable INT,
    FOREIGN KEY (id_responsable) REFERENCES usuarios(id_usuario) ON DELETE SET NULL
);

CREATE TABLE tareas (
    id_tarea INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(200) NOT NULL,
    descripcion TEXT,
    prioridad VARCHAR(50) DEFAULT 'Media', -- baja, media, alta, urgente
    estado VARCHAR(50) DEFAULT 'Pendiente', -- pendiente, en progreso, Completada
    fecha_inicio DATE,
    fecha_limite DATE,
    id_proyecto INT,
    id_responsable INT,
    FOREIGN KEY (id_proyecto) REFERENCES proyectos(id_proyecto) ON DELETE CASCADE,
    FOREIGN KEY (id_responsable) REFERENCES usuarios(id_usuario) ON DELETE SET NULL
);

CREATE TABLE notificaciones (
    id_notificacion INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL,
    mensaje VARCHAR(255) NOT NULL,
    leido BOOLEAN DEFAULT FALSE,
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario) ON DELETE CASCADE
);

-- 6. Insertar un Usuario de Prueba para el Login
-- Nota: El hash '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918' 
-- equivale a la contraseña 'admin123' encriptada en SHA-256.

INSERT INTO usuarios (nombre, correo, password_hash, rol, telefono, departamento) 
VALUES (
    'Administrador TaskMate', 
    'admin@miempresa.com', 
    '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 
    'Administrador', 
    '+57 300 000 0000', 
    'Gerencia'
);