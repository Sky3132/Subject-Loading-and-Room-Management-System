-- Add Max Load to Faculty table
ALTER TABLE tblFaculty ADD MaxLoad INT DEFAULT 18; 

-- Add Units to Subject table
ALTER TABLE tblsubject ADD Units INT DEFAULT 3;

-- Add Status to Loading table for the approval workflow
ALTER TABLE tblFacultyLoading ADD Status VARCHAR(20) DEFAULT 'Approved';