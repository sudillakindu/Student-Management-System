USE StudentManagementSystem;

SELECT * FROM Student ;  StudentID, Name, DOB  ;

INSERT INTO Branch (BranchID, BranchName, BranchHead, BContactNumber, BranchEmail, Location, NumberOfCourse) 
VALUES 
    ( 'B001' , 'Colombo Campus'    , 'Prof. Perera Jayawardena'   , '+94112456789' , 'colombo.campus@nibm.lk'    , 'Colombo 07' , 12 ),
    ( 'B002' , 'Rajagiriya Campus' , 'Prof. Kamal Wijesekara'     , '+94112789456' , 'rajagiriya.campus@nibm.lk' , 'Rajagiriya' , 8  ),
    ( 'B003' , 'Kandy Campus'      , 'Prof. Nimal Bandara'        , '+94812345678' , 'kandy.campus@nibm.lk'      , 'Kandy'      , 10 ),
    ( 'B004' , 'Kurunegala Campus' , 'Prof. Sunil Ratnayake'      , '+94372234567' , 'kurunegala.campus@nibm.lk' , 'Kurunegala' , 6  ),
    ( 'B005' , 'Galle Campus'      , 'Prof. Asanka De Silva'      , '+94912234567' , 'galle.campus@nibm.lk'      , 'Galle'      , 7  ),
    ( 'B006' , 'Matara Campus'     , 'Prof. Lakshman Gunawardena' , '+94412345678' , 'matara.campus@nibm.lk'     , 'Matara'     , 5  ),
    ( 'B007' , 'Kirulapone NIC'    , 'Prof. Chaminda Fernando'    , '+94112789123' , 'kirulapone.nic@nibm.lk'    , 'Kirulapone' , 4  ),
    ( 'B008' , 'Kandy KIC'         , 'Prof. Ranjith Dissanayake'  , '+94812345123' , 'kandy.kic@nibm.lk'         , 'Kandy'      , 3  );

SELECT * FROM Branch;

INSERT INTO Course (CourseID, CourseName, Credit, CourseDescription, CoursePrice) VALUES 
    ('C001', 'BSc (Hons) in Software Engineering', 36, 'Comprehensive degree covering software development, design patterns, and project management', 875000.00),
    ('C002', 'Advanced Diploma in Business Management', 24, 'Professional qualification in modern business practices and management', 450000.00),
    ('C003', 'Higher National Diploma in Network Engineering', 30, 'Advanced networking, cybersecurity, and system administration studies', 650000.00),
    ('C004', 'Professional Diploma in Accounting', 28, 'Complete study of financial accounting and taxation systems', 525000.00),
    ('C005', 'Certificate in Digital Marketing', 15, 'Modern digital marketing strategies and social media management', 275000.00),
    ('C006', 'BSc in Computer Science', 38, 'Core computer science concepts, programming, and software development', 925000.00),
    ('C007', 'Diploma in Human Resource Management', 20, 'Strategic HR practices and employee relations management', 375000.00),
    ('C008', 'Advanced Certificate in Graphic Design', 16, 'Creative design principles and digital media production', 225000.00),
    ('C009', 'Higher Diploma in Tourism Management', 25, 'Tourism industry operations and hospitality management', 425000.00),
    ('C010', 'Certificate in Mobile App Development', 18, 'Mobile application development for iOS and Android platforms', 350000.00),
    ('C011', 'Diploma in Marketing Management', 22, 'Strategic marketing principles and brand management', 395000.00),
    ('C012', 'Advanced Diploma in Civil Engineering', 32, 'Infrastructure design and construction management principles', 750000.00),
    ('C013', 'Certificate in Web Development', 16, 'Modern web technologies and responsive design principles', 285000.00),
    ('C014', 'Diploma in Interior Design', 24, 'Spatial design principles and interior architecture', 445000.00),
    ('C015', 'Higher National Diploma in IT', 34, 'Comprehensive IT systems and software solutions', 725000.00),
    ('C016', 'Certificate in English for Business', 12, 'Business English communication and writing skills', 175000.00),
    ('C017', 'Diploma in Project Management', 20, 'Project planning, execution, and team management', 425000.00),
    ('C018', 'Advanced Certificate in Cybersecurity', 18, 'Network security and cyber threat prevention', 385000.00),
    ('C019', 'Higher Diploma in Psychology', 28, 'Human behavior and psychological principles', 525000.00),
    ('C020', 'Certificate in Data Analytics', 16, 'Data analysis techniques and business intelligence', 325000.00),
    ('C021', 'Diploma in Photography', 15, 'Digital photography and image editing techniques', 245000.00),
    ('C022', 'Advanced Diploma in Artificial Intelligence', 26, 'AI algorithms and machine learning applications', 675000.00),
    ('C023', 'Certificate in Supply Chain Management', 14, 'Logistics and supply chain optimization', 295000.00),
    ('C024', 'Higher National Diploma in Agriculture', 30, 'Modern agricultural practices and farm management', 495000.00),
    ('C025', 'Diploma in Fashion Design', 22, 'Fashion concept development and garment design', 385000.00),
    ('C026', 'Advanced Certificate in Cloud Computing', 20, 'Cloud infrastructure and service management', 425000.00),
    ('C027', 'Certificate in Digital Banking', 16, 'Modern banking technologies and fintech solutions', 275000.00),
    ('C028', 'Higher Diploma in Media Studies', 26, 'Mass communication and digital media production', 475000.00),
    ('C029', 'Diploma in Hotel Management', 24, 'Hospitality operations and guest relations', 395000.00),
    ('C030', 'Advanced Certificate in Quality Assurance', 18, 'Software testing and quality management', 325000.00),
    ('C031', 'Certificate in Environmental Science', 15, 'Environmental protection and sustainable practices', 265000.00),
    ('C032', 'Higher National Diploma in Engineering', 36, 'Engineering principles and industrial applications', 825000.00),
    ('C033', 'Diploma in Beauty Therapy', 20, 'Professional beauty treatments and salon management', 295000.00),
    ('C034', 'Advanced Certificate in 3D Animation', 22, '3D modeling and animation techniques', 445000.00),
    ('C035', 'Certificate in Business Analytics', 16, 'Business data analysis and reporting methods', 315000.00),
    ('C036', 'Higher Diploma in Architecture', 32, 'Architectural design and building regulations', 775000.00),
    ('C037', 'Diploma in Music Production', 24, 'Digital music production and sound engineering', 425000.00),
    ('C038', 'Advanced Certificate in IoT', 18, 'Internet of Things technology and applications', 365000.00),
    ('C039', 'Certificate in Content Writing', 14, 'Digital content creation and copywriting', 195000.00),
    ('C040', 'Higher National Diploma in Biotechnology', 34, 'Biotechnology principles and laboratory practices', 695000.00);

INSERT INTO Course (CourseID, CourseName, Credit, CourseDescription, CoursePrice) VALUES 
    ('C041', 'BSc in Artificial Intelligence', 40, 'Advanced study in AI algorithms, machine learning, and deep learning', 985000.00),
    ('C042', 'Diploma in Sports Management', 25, 'Sports administration and event management techniques', 445000.00),
    ('C043', 'Certificate in Commercial Cookery', 18, 'Professional cooking and restaurant management', 325000.00),
    ('C044', 'Higher National Diploma in Mechatronics', 35, 'Robotics and automated systems engineering', 725000.00),
    ('C045', 'Advanced Certificate in Video Production', 16, 'Digital video production and post-production techniques', 285000.00),
    ('C046', 'Diploma in Pharmaceutical Sciences', 30, 'Drug development and pharmaceutical processes', 565000.00),
    ('C047', 'BSc in Marine Biology', 38, 'Study of marine ecosystems and ocean conservation', 895000.00),
    ('C048', 'Certificate in Digital Forensics', 20, 'Computer forensics and cybercrime investigation', 425000.00),
    ('C049', 'Higher Diploma in Renewable Energy', 32, 'Sustainable energy systems and green technology', 685000.00),
    ('C050', 'Advanced Certificate in Gemology', 15, 'Gem identification and jewelry assessment', 375000.00),
    ('C051', 'Diploma in Aviation Management', 28, 'Airport operations and flight service management', 625000.00),
    ('C052', 'Certificate in Tea Manufacturing', 16, 'Tea processing and quality control methods', 245000.00),
    ('C053', 'Higher National Diploma in Quantity Surveying', 36, 'Construction cost management and estimation', 775000.00),
    ('C054', 'Advanced Diploma in Game Development', 34, '3D game design and interactive media creation', 695000.00),
    ('C055', 'Certificate in Ayurvedic Medicine', 22, 'Traditional healing practices and herbal medicine', 385000.00),
    ('C056', 'BSc in Data Science', 40, 'Big data analytics and statistical modeling', 925000.00),
    ('C057', 'Diploma in Textile Technology', 26, 'Fabric production and textile quality assurance', 485000.00),
    ('C058', 'Certificate in Wedding Planning', 15, 'Event coordination and wedding design concepts', 265000.00),
    ('C059', 'Higher Diploma in Food Technology', 32, 'Food processing and quality management systems', 595000.00),
    ('C060', 'Advanced Certificate in Digital Banking', 18, 'Online banking systems and financial technology', 345000.00),
    ('C061', 'Diploma in Automotive Engineering', 30, 'Vehicle mechanics and automotive systems', 545000.00),
    ('C062', 'Certificate in Social Media Marketing', 16, 'Digital platform marketing and content strategy', 295000.00),
    ('C063', 'Higher National Diploma in Forestry', 34, 'Forest management and conservation techniques', 645000.00),
    ('C064', 'Advanced Diploma in Interior Architecture', 36, 'Spatial design and architectural visualization', 755000.00),
    ('C065', 'Certificate in Mobile App Security', 20, 'Application security and vulnerability assessment', 425000.00),
    ('C066', 'BSc in Aquaculture', 38, 'Fish farming and aquatic resource management', 825000.00),
    ('C067', 'Diploma in Radio Broadcasting', 24, 'Radio production and on-air presentation skills', 435000.00),
    ('C068', 'Certificate in Organic Farming', 15, 'Sustainable agriculture and organic certification', 255000.00),
    ('C069', 'Higher Diploma in Logistics Management', 30, 'Supply chain optimization and transport management', 575000.00),
    ('C070', 'Advanced Certificate in Blockchain', 22, 'Blockchain technology and cryptocurrency systems', 465000.00),
    ('C071', 'Diploma in Dental Technology', 28, 'Dental prosthetics and laboratory techniques', 525000.00),
    ('C072', 'Certificate in Hardware Engineering', 16, 'Computer hardware maintenance and troubleshooting', 285000.00),
    ('C073', 'Higher National Diploma in Sound Engineering', 32, 'Audio production and sound system design', 625000.00),
    ('C074', 'Advanced Diploma in Virtual Reality', 34, 'VR content creation and immersive technologies', 695000.00),
    ('C075', 'Certificate in Export Agriculture', 18, 'Agricultural export procedures and standards', 315000.00),
    ('C076', 'BSc in Biomedical Science', 40, 'Medical laboratory sciences and clinical research', 895000.00),
    ('C077', 'Diploma in Coconut Technology', 26, 'Coconut processing and product development', 445000.00),
    ('C078', 'Certificate in Legal Studies', 20, 'Basic law principles and legal procedures', 375000.00),
    ('C079', 'Higher Diploma in Marine Engineering', 36, 'Ship systems and maritime operations', 775000.00),
    ('C080', 'Advanced Certificate in Smart Agriculture', 22, 'Technology-driven farming and precision agriculture', 425000.00);

SELECT * FROM Course;

INSERT INTO Student (StudentID, Name, DOB, Age, NIC, Email, PhoneNumber, Address, EnrollmentDate, BranchID, Status) 
VALUES 
('S0001', 'Kavinda Perera', '2000-05-15', 24, '200013567890', 'kavinda.perera@gmail.com', '0771234567', 'No.45, Temple Road, Colombo 05', '2024-01-15 09:30:00', 'B001', 'Active'),
('S0002', 'Malini Gunawardena', '1995-08-22', 29, '199534567891', 'malini.guna@yahoo.com', '0712345678', '78/A, Galle Road, Mount Lavinia', '2023-12-10 14:15:00', 'B003', 'Active'),
('S0003', 'Dinesh Rajapaksa', '2005-03-10', 19, '200523456789', 'dinesh.raja@gmail.com', '0763456789', '123, Main Street, Wellawatte', '2024-02-20 11:45:00', 'B002', 'Completed'),
('S0004', 'Kumari Samaraweera', '1990-11-30', 34, '199067891234', 'kumari.sam@hotmail.com', '0724567890', '15, Park Road, Dehiwala', '2023-11-25 10:00:00', 'B004', 'Dropped'),
('S0005', 'Nuwan Bandara', '1998-07-25', 26, '199845678912', 'nuwan.bandara@gmail.com', '0756789012', '234/B, Hill Street, Nugegoda', '2024-03-05 13:20:00', 'B001', 'Active'),
('S0006', 'Amara Dissanayake', '2002-04-18', 22, '200245678913', 'amara.dissa@gmail.com', '0778901234', '45, Temple Road, Kandy', '2024-01-20 10:30:00', 'B005', 'Active'),
('S0007', 'Rohan Silva', '1997-09-12', 27, '199756789014', 'rohan.silva@yahoo.com', '0715678901', '67, Peradeniya Road, Kandy', '2023-12-15 15:45:00', 'B002', 'Completed'),
('S0008', 'Dilini Wickramasinghe', '2003-06-25', 21, '200367890125', 'dilini.wickra@gmail.com', '0764567890', '89, Hill Street, Katugastota', '2024-02-10 09:15:00', 'B003', 'Active'),
('S0009', 'Lakmal Jayawardena', '1994-12-08', 30, '199478901236', 'lakmal.jaya@hotmail.com', '0723456789', '12/A, Lake Road, Ampitiya', '2023-11-30 14:00:00', 'B006', 'Active'),
('S0010', 'Sachini Fernando', '1999-03-15', 25, '199989012347', 'sachini.fer@gmail.com', '0757890123', '34, Temple Square, Peradeniya', '2024-03-10 11:30:00', 'B004', 'Active'),
('S0011', 'Thisara Ranasinghe', '2001-08-20', 23, '200190123458', 'thisara.rana@gmail.com', '0779012345', '56, Beach Road, Galle Fort', '2024-01-25 13:45:00', 'B007', 'Active'),
('S0012', 'Nilmini De Silva', '1996-05-17', 28, '199601234569', 'nilmini.de@yahoo.com', '0716789012', '78, Main Street, Unawatuna', '2023-12-20 10:15:00', 'B008', 'Completed'),
('S0013', 'Chaminda Herath', '2004-02-28', 20, '200412345670', 'chaminda.her@gmail.com', '0765678901', '90, Sea View Road, Hikkaduwa', '2024-02-15 15:30:00', 'B001', 'Active'),
('S0014', 'Sanduni Peris', '1993-10-05', 31, '199323456781', 'sanduni.peris@hotmail.com', '0722345678', '23/C, Beach Side, Ahangama', '2023-12-05 09:45:00', 'B002', 'Dropped'),
('S0015', 'Isuru Mendis', '2000-01-12', 24, '200034567892', 'isuru.mendis@gmail.com', '0758901234', '45, Harbor Road, Galle', '2024-03-15 14:20:00', 'B003', 'Active'),
('S0016', 'Pradeep Sivarajah', '1998-11-28', 26, '199845678903', 'pradeep.siva@gmail.com', '0770123456', '67, KKS Road, Jaffna', '2024-01-30 11:00:00', 'B004', 'Active'),
('S0017', 'Thilini Rajaratnam', '1995-07-14', 29, '199556789014', 'thilini.raja@yahoo.com', '0717890123', '89, Hospital Road, Nallur', '2023-12-25 16:30:00', 'B005', 'Active'),
('S0018', 'Kumar Selvarajah', '2005-04-30', 19, '200567890125', 'kumar.selva@gmail.com', '0766789012', '12, Temple Road, Manipay', '2024-02-25 10:45:00', 'B006', 'Completed'),
('S0019', 'Deepa Chandran', '1992-09-22', 32, '199234567836', 'deepa.chan@hotmail.com', '0721234567', '34/B, Point Pedro Road, Jaffna', '2023-12-10 13:15:00', 'B007', 'Active'),
('S0020', 'Ravi Thanaraj', '1997-06-08', 27, '199778901247', 'ravi.thana@gmail.com', '0759012345', '56, Palaly Road, Kopay', '2024-03-20 15:45:00', 'B008', 'Active'),
('S0021', 'Mohamed Farook', '2002-12-15', 22, '200289012358', 'mohamed.far@gmail.com', '0771234568', '78, Trinco Road, Batticaloa', '2024-02-01 12:30:00', 'B001', 'Active'),
('S0022', 'Fathima Rizwan', '1994-03-27', 30, '199490123469', 'fathima.riz@yahoo.com', '0718901234', '90, Lake View, Kattankudy', '2023-12-30 09:00:00', 'B002', 'Completed'),
('S0023', 'Abdul Hameed', '2003-08-11', 21, '200301234580', 'abdul.ham@gmail.com', '0767890123', '12, Beach Road, Eravur', '2024-03-01 14:45:00', 'B003', 'Active'),
('S0024', 'Zainab Hussein', '1991-05-19', 33, '199145678947', 'zainab.hus@hotmail.com', '0720123456', '34, Main Street, Kaluwanchikudy', '2023-12-15 11:30:00', 'B004', 'Dropped'),
('S0025', 'Ahmed Naseer', '1999-02-23', 25, '199923456858', 'ahmed.nas@gmail.com', '0750123456', '56, Hospital Road, Batticaloa', '2024-03-25 16:15:00', 'B005', 'Active'),
('S0026', 'Sampath Weerasinghe', '2001-10-07', 23, '200134567869', 'sampath.wee@gmail.com', '0772345679', '78, Beach Road, Matara', '2024-02-05 10:00:00', 'B006', 'Active'),
('S0027', 'Chamari Attanayake', '1996-01-31', 28, '199601234670', 'chamari.att@yahoo.com', '0719012345', '90, Galle Road, Weligama', '2024-01-05 15:15:00', 'B007', 'Active'),
('S0028', 'Duminda Kulathunga', '2004-07-16', 20, '200412345781', 'duminda.kul@gmail.com', '0768901234', '12, Temple Road, Dikwella', '2024-03-05 11:45:00', 'B008', 'Completed'),
('S0029', 'Nilushi Gamage', '1993-04-03', 31, '199356789058', 'nilushi.gam@hotmail.com', '0723456780', '34, Main Street, Dondra', '2023-12-20 14:30:00', 'B001', 'Active'),
('S0030', 'Thilak Rathnayake', '2000-11-26', 24, '200067890169', 'thilak.rath@gmail.com', '0751234567', '56, Harbor Road, Matara', '2024-03-30 09:30:00', 'B002', 'Active'),
('S0031', 'Asanka Rajapakse', '1998-09-09', 26, '199878901270', 'asanka.raja@gmail.com', '0773456780', '78, Dambulla Road, Kurunegala', '2024-02-10 13:00:00', 'B003', 'Active'),
('S0032', 'Dilrukshi Seneviratne', '1995-06-13', 29, '199589012381', 'dilrukshi.sen@yahoo.com', '0710123456', '90, Kandy Road, Wariyapola', '2024-01-10 16:45:00', 'B004', 'Completed'),
('S0033', 'Prasanna Karunaratne', '2005-01-28', 19, '200523456892', 'prasanna.kar@gmail.com', '0769012345', '12, Temple Road, Mawathagama', '2024-03-10 12:15:00', 'B005', 'Active'),
('S0034', 'Shanika Dharmawardena', '1992-12-01', 32, '199267890303', 'shanika.dha@hotmail.com', '0724567891', '34, Lake Road, Kuliyapitiya', '2023-12-25 10:45:00', 'B006', 'Dropped'),
('S0035', 'Buddhika Jayasuriya', '1997-03-24', 27, '199790123414', 'buddhika.jay@gmail.com', '0752345678', '56, Main Street, Kurunegala', '2024-04-01 15:00:00', 'B007', 'Active'),
('S0036', 'Upul Wijayawardena', '2002-08-05', 22, '200201234525', 'upul.wija@gmail.com', '0774567891', '78, Sacred City Road, Anuradhapura', '2024-02-15 11:15:00', 'B008', 'Active'),
('S0037', 'Shanthi Ratnayake', '1994-05-20', 30, '199445678936', 'shanthi.rat@yahoo.com', '0711234567', '90, New Town Road, Mihintale', '2024-01-15 14:30:00', 'B001', 'Active'),
('S0038', 'Chandana Pathirana', '2003-02-14', 21, '200312345647', 'chandana.pat@gmail.com', '0760123456', '12, Temple Road, Kekirawa', '2024-03-15 09:45:00', 'B002', 'Completed'),
('S0039', 'Anusha Wickramaratne', '1991-11-07', 33, '199178901258', 'anusha.wic@hotmail.com', '0725678902', '34, Lake View Road, Thalawa', '2023-12-30 16:00:00', 'B003', 'Active'),
('S0040', 'Mahesh Premadasa', '1999-07-30', 25, '199990123469', 'mahesh.pre@gmail.com', '0753456789', '56, Historic Park Road, Anuradhapura', '2024-04-05 12:45:00', 'B004', 'Active');

INSERT INTO Student (StudentID, Name, DOB, Age, NIC, Email, PhoneNumber, Address, EnrollmentDate, BranchID, Status) 
VALUES 
('S0041', 'Sajith Kumara', '2001-04-12', 23, '200145678901', 'sajith.kum@gmail.com', '0771234590', '23/A, Hill Street, Badulla', '2024-01-18 09:30:00', 'B005', 'Active'),
('S0042', 'Dilhani Ramanayake', '1996-08-25', 28, '199667890123', 'dilhani.ram@yahoo.com', '0712345691', '45, Hospital Road, Bandarawela', '2023-12-12 14:15:00', 'B006', 'Completed'),
('S0043', 'Kapila Senanayake', '2004-03-18', 20, '200489012345', 'kapila.sen@gmail.com', '0763456792', '67, Market Road, Hali-Ela', '2024-02-22 11:45:00', 'B007', 'Active'),
('S0044', 'Madhavi Wickremasinghe', '1992-11-30', 32, '199290123456', 'madhavi.wic@hotmail.com', '0724567893', '89, Tea Estate Road, Haputale', '2023-11-28 10:00:00', 'B008', 'Dropped'),
('S0045', 'Ruwan Dissanayake', '1999-07-15', 25, '199912345678', 'ruwan.dis@gmail.com', '0755678994', '12, Station Road, Ella', '2024-03-07 13:20:00', 'B001', 'Active'),
('S0046', 'Namal Ekanayake', '2002-09-20', 22, '200234567890', 'namal.eka@gmail.com', '0776789095', '34/B, Gem Town Road, Ratnapura', '2024-01-22 10:30:00', 'B002', 'Active'),
('S0047', 'Sewwandi Bandara', '1995-12-05', 29, '199556789012', 'sewwandi.ban@yahoo.com', '0717890196', '56, New Town, Embilipitiya', '2023-12-17 15:45:00', 'B003', 'Active'),
('S0048', 'Lahiru Weerasinghe', '2003-06-28', 21, '200378901234', 'lahiru.wee@gmail.com', '0768901297', '78, Temple Road, Balangoda', '2024-02-12 09:15:00', 'B004', 'Completed'),
('S0049', 'Nimali Jayasinghe', '1994-02-14', 30, '199490123456', 'nimali.jay@hotmail.com', '0729012398', '90, Lake View, Kahawatta', '2023-12-02 14:00:00', 'B005', 'Active'),
('S0050', 'Priyantha Silva', '1998-05-30', 26, '199812345678', 'priyantha.sil@gmail.com', '0750123499', '11, Main Street, Pelmadulla', '2024-03-12 11:30:00', 'B006', 'Active'),
('S0051', 'Rajkumar Thiruchelvam', '2000-10-08', 24, '200034567891', 'rajkumar.thi@gmail.com', '0771234600', '23, Harbor Road, Trincomalee', '2024-01-27 13:45:00', 'B007', 'Active'),
('S0052', 'Malathi Sivakumar', '1997-03-22', 27, '199756789123', 'malathi.siv@yahoo.com', '0712345701', '45, Beach Road, Nilaveli', '2023-12-22 10:15:00', 'B008', 'Completed'),
('S0053', 'Vijay Rajaratnam', '2005-01-15', 19, '200578912345', 'vijay.raja@gmail.com', '0763456802', '67, Fort Road, Uppuveli', '2024-02-17 15:30:00', 'B001', 'Active'),
('S0054', 'Sharmila Kanthan', '1993-08-28', 31, '199390123457', 'sharmila.kan@hotmail.com', '0724567903', '89, Temple Street, Muttur', '2023-12-07 09:45:00', 'B002', 'Dropped'),
('S0055', 'Nimal Thilakaratne', '2001-04-05', 23, '200112345679', 'nimal.thi@gmail.com', '0755678904', '12, Navy Road, Kinniya', '2024-03-17 14:20:00', 'B003', 'Active'),
('S0056', 'Anura Bandara', '1999-11-12', 25, '199934567892', 'anura.ban@gmail.com', '0776789005', '34, Ancient City Road, Polonnaruwa', '2024-02-01 11:00:00', 'B004', 'Active'),
('S0057', 'Pushpa Ranaweera', '1996-06-25', 28, '199656789124', 'pushpa.ran@yahoo.com', '0717890106', '56, Lake Circuit, Kaduruwela', '2023-12-27 16:30:00', 'B005', 'Active'),
('S0058', 'Saman Gunawardana', '2004-09-18', 20, '200478912346', 'saman.gun@gmail.com', '0768901207', '78, Rice Mill Road, Hingurakgoda', '2024-02-27 10:45:00', 'B006', 'Completed'),
('S0059', 'Wasana Perera', '1992-02-03', 32, '199290123458', 'wasana.per@hotmail.com', '0729012308', '90, Temple Road, Medirigiriya', '2023-12-12 13:15:00', 'B007', 'Active'),
('S0060', 'Kasun Rathnayaka', '1997-07-20', 27, '199712345680', 'kasun.rat@gmail.com', '0750123409', '11, New Town, Manampitiya', '2024-03-22 15:45:00', 'B008', 'Active'),
('S0061', 'Gayan Fernando', '2002-12-28', 22, '200234567893', 'gayan.fer@gmail.com', '0771234510', '23, Hill Road, Matale', '2024-02-03 12:30:00', 'B001', 'Active'),
('S0062', 'Tharushi Karunatilaka', '1994-05-15', 30, '199456789125', 'tharushi.kar@yahoo.com', '0712345611', '45, Temple Street, Dambulla', '2024-01-02 09:00:00', 'B002', 'Completed'),
('S0063', 'Hemantha Wijesekara', '2003-08-30', 21, '200378912347', 'hemantha.wij@gmail.com', '0763456712', '67, Cave Road, Sigiriya', '2024-03-03 14:45:00', 'B003', 'Active'),
('S0064', 'Chathurika Silva', '1991-03-12', 33, '199190123459', 'chathurika.sil@hotmail.com', '0724567813', '89, Market Road, Ukuwela', '2023-12-17 11:30:00', 'B004', 'Dropped'),
('S0065', 'Thushara Pathirana', '2000-01-25', 24, '200012345681', 'thushara.pat@gmail.com', '0755678914', '12, Spice Garden Road, Rattota', '2024-03-27 16:15:00', 'B005', 'Active'),
('S0066', 'Udaya Liyanage', '2001-10-18', 23, '200134567894', 'udaya.liy@gmail.com', '0776789015', '34, Port Road, Hambantota', '2024-02-07 10:00:00', 'B006', 'Active'),
('S0067', 'Sudarshani Amarasinghe', '1995-04-30', 29, '199556789126', 'sudarshani.ama@yahoo.com', '0717890116', '56, Salt Lake Road, Tissamaharama', '2024-01-07 15:15:00', 'B007', 'Active'),
('S0068', 'Lalith Kumara', '2004-07-23', 20, '200478912348', 'lalith.kum@gmail.com', '0768901217', '78, Wildlife Road, Kirinda', '2024-03-07 11:45:00', 'B008', 'Completed'),
('S0069', 'Yamuna Wickremaratne', '1993-12-08', 31, '199390123460', 'yamuna.wic@hotmail.com', '0729012318', '90, Beach Road, Tangalle', '2023-12-22 14:30:00', 'B001', 'Active'),
('S0070', 'Janaka Herath', '1998-09-15', 26, '199812345682', 'janaka.her@gmail.com', '0750123419', '11, Temple Road, Beliatta', '2024-04-01 09:30:00', 'B002', 'Active'),
('S0071', 'Samantha Dissanayake', '2002-06-10', 22, '200234567895', 'samantha.dis@gmail.com', '0771234520', '23, Hill Street, Kegalle', '2024-02-12 13:00:00', 'B003', 'Active'),
('S0072', 'Chamila Senaratne', '1994-01-23', 30, '199456789127', 'chamila.sen@yahoo.com', '0712345621', '45, Temple Road, Mawanella', '2024-01-12 16:45:00', 'B004', 'Completed'),
('S0073', 'Rangana Peris', '2003-04-05', 21, '200378912349', 'rangana.per@gmail.com', '0763456722', '67, River Road, Rambukkana', '2024-03-12 12:15:00', 'B005', 'Active'),
('S0074', 'Nilmini Gunasekara', '1991-11-18', 33, '199190123461', 'nilmini.gun@hotmail.com', '0724567823', '89, Railway Road, Dehiowita', '2023-12-27 10:45:00', 'B006', 'Dropped'),
('S0075', 'Indika Jayawardena', '1999-08-30', 25, '199912345683', 'indika.jay@gmail.com', '0755678924', '12, Town Road, Warakapola', '2024-04-03 15:00:00', 'B007', 'Active'),
('S0076', 'Ravindu Weerakoon', '2000-03-15', 24, '200034567896', 'ravindu.wee@gmail.com', '0776789025', '34, Lagoon Road, Puttalam', '2024-02-14 11:15:00', 'B008', 'Active'),
('S0077', 'Dulani Rajapaksa', '1995-12-28', 29, '199556789128', 'dulani.raj@yahoo.com', '0717890126', '56, Salt Pan Road, Chilaw', '2024-01-14 14:30:00', 'B001', 'Active'),
('S0078', 'Suranga Fonseka', '2004-09-10', 20, '200478912350', 'suranga.fon@gmail.com', '0768901227', '78, Fish Market Road, Wennappuwa', '2024-03-14 09:45:00', 'B002', 'Completed'),
('S0079', 'Dayani Senanayake', '1992-06-23', 32, '199290123462', 'dayani.sen@hotmail.com', '0729012328', '90, Beach Road, Marawila', '2023-12-29 16:00:00', 'B003', 'Active'),
('S0080', 'Chandimal Silva', '1997-03-05', 27, '199712345684', 'chandimal.sil@gmail.com', '0750123429', '11, Church Road, Mundel', '2024-04-05 12:45:00', 'B004', 'Active');

INSERT INTO Student (StudentID, Name, DOB, Age, NIC, Email, PhoneNumber, Address, EnrollmentDate, BranchID, Status) 
VALUES 
('S0081', 'Vijitha Ratnayake', '2002-05-18', 22, '200245678901', 'vijitha.rat@gmail.com', '0771234530', '45/A, Tea Estate Road, Nuwara Eliya', '2024-01-19 09:30:00', 'B001', 'Active'),
('S0082', 'Kanthi Pushpakumara', '1995-09-22', 29, '199567890123', 'kanthi.pus@yahoo.com', '0712345631', '67, Hill Road, Hatton', '2023-12-14 14:15:00', 'B002', 'Completed'),
('S0083', 'Sunil Wimalasena', '2004-02-15', 20, '200429012348', 'sunil.wim@gmail.com', '0763456732', '89, Lake Road, Maskeliya', '2024-02-24 11:45:00', 'B003', 'Active'),
('S0084', 'Rani Kumarihamy', '1992-11-30', 32, '199290123457', 'rani.kum@hotmail.com', '0724567833', '12, Station Road, Talawakele', '2023-11-29 10:00:00', 'B004', 'Dropped'),
('S0085', 'Asela Jayasinghe', '1999-07-12', 25, '199912345679', 'asela.jay@gmail.com', '0755678934', '34, Garden Road, Ragala', '2024-03-09 13:20:00', 'B005', 'Active'),
('S0086', 'Senthil Kumar', '2001-10-25', 23, '200134567892', 'senthil.kum@gmail.com', '0776789035', '56, Temple Street, Vavuniya', '2024-01-24 10:30:00', 'B006', 'Active'),
('S0087', 'Vimala Sivakumar', '1996-03-08', 28, '199667890124', 'vimala.siv@yahoo.com', '0717890136', '78, Market Road, Vavuniya', '2023-12-19 15:45:00', 'B007', 'Active'),
('S0088', 'Rajan Thirunavukarasu', '2003-08-20', 21, '200378901235', 'rajan.thi@gmail.com', '0768901237', '90, Hospital Road, Cheddikulam', '2024-02-14 09:15:00', 'B008', 'Completed'),
('S0089', 'Lalitha Parameshwaran', '1994-01-15', 30, '199490123458', 'lalitha.par@hotmail.com', '0729012338', '23, Railway Road, Omanthai', '2023-12-04 14:00:00', 'B001', 'Active'),
('S0090', 'Mohan Rajaratnam', '1998-06-30', 26, '199812345680', 'mohan.raj@gmail.com', '0750123439', '45, New Town, Vavuniya', '2024-03-14 11:30:00', 'B002', 'Active'),
('S0091', 'Antony Fernando', '2000-12-05', 24, '200034567893', 'antony.fer@gmail.com', '0771234540', '67, Sea Street, Mannar', '2024-01-29 13:45:00', 'B003', 'Active'),
('S0092', 'Mary Croos', '1997-04-18', 27, '199767890125', 'mary.cro@yahoo.com', '0712345641', '89, Church Road, Talaimannar', '2023-12-24 10:15:00', 'B004', 'Completed'),
('S0093', 'Joseph Pillai', '2005-01-30', 19, '200578901236', 'joseph.pil@gmail.com', '0763456742', '12, Pier Road, Pesalai', '2024-02-19 15:30:00', 'B005', 'Active'),
('S0094', 'Christina Michael', '1993-08-12', 31, '199390123459', 'christina.mic@hotmail.com', '0724567843', '34, Beach Road, Vankalai', '2023-12-09 09:45:00', 'B006', 'Dropped'),
('S0095', 'Sebastian Cruz', '2001-05-25', 23, '200112345681', 'sebastian.cru@gmail.com', '0755678944', '56, Fisher Lane, Mannar', '2024-03-19 14:20:00', 'B007', 'Active'),
('S0096', 'Mohammed Riyas', '1999-11-08', 25, '199934567894', 'mohammed.riy@gmail.com', '0776789045', '78, Main Street, Ampara', '2024-02-04 11:00:00', 'B008', 'Active'),
('S0097', 'Fathima Nazreen', '1996-07-20', 28, '199667890126', 'fathima.naz@yahoo.com', '0717890146', '90, Mosque Road, Kalmunai', '2023-12-29 16:30:00', 'B001', 'Active'),
('S0098', 'Abdul Majeed', '2004-10-15', 20, '200478901237', 'abdul.maj@gmail.com', '0768901247', '23, Beach Road, Akkaraipattu', '2024-03-01 10:45:00', 'B002', 'Completed'),
('S0099', 'Sithy Raheem', '1992-02-28', 32, '199290123460', 'sithy.rah@hotmail.com', '0729012348', '45, Market Road, Sainthamaruthu', '2023-12-14 13:15:00', 'B003', 'Active'),
('S0100', 'Ahmed Saheed', '1997-09-10', 27, '199712345682', 'ahmed.sah@gmail.com', '0750123449', '67, Town Road, Nintavur', '2024-03-24 15:45:00', 'B004', 'Active'),
('S0101', 'Ajith Kumara', '2002-04-15', 22, '200233567525', 'ajith.kum@gmail.com', '0771234550', '89, Temple Road, Monaragala', '2024-02-06 12:30:00', 'B005', 'Active'),
('S0102', 'Sriyani Ranasinghe', '1994-08-28', 30, '199467890127', 'sriyani.ran@yahoo.com', '0712345651', '12, New Town, Wellawaya', '2024-01-04 09:00:00', 'B006', 'Completed'),
('S0103', 'Danesh Vithanage', '2003-01-12', 21, '200378901238', 'danesh.vit@gmail.com', '0763456752', '34, Main Street, Bibile', '2024-03-06 14:45:00', 'B007', 'Active'),
('S0104', 'Kumudini Perera', '1991-06-25', 33, '199192123461', 'kumudini.per@hotmail.com', '0724567853', '56, Tank Road, Buttala', '2023-12-19 11:30:00', 'B008', 'Dropped'),
('S0105', 'Lasantha Silva', '2000-03-18', 24, '200012345683', 'lasantha.sil@gmail.com', '0755678954', '78, Rice Mill Road, Siyambalanduwa', '2024-03-29 16:15:00', 'B001', 'Active'),
('S0106', 'Navaratnam Krishnan', '2001-08-30', 23, '200134567896', 'navaratnam.kri@gmail.com', '0776789055', '90, A9 Road, Kilinochchi', '2024-02-09 10:00:00', 'B002', 'Active'),
('S0107', 'Suganthini Balasingam', '1995-12-15', 29, '199567890128', 'suganthini.bal@yahoo.com', '0717890156', '23, Temple Road, Paranthan', '2024-01-09 15:15:00', 'B003', 'Active'),
('S0108', 'Karthik Shanmugam', '2004-05-28', 20, '200478901239', 'karthik.sha@gmail.com', '0768901257', '45, Tank Road, Kilinochchi', '2024-03-09 11:45:00', 'B004', 'Completed'),
('S0109', 'Tharsini Vigneswaran', '1993-10-10', 31, '199390123462', 'tharsini.vig@hotmail.com', '0729012358', '67, Market Road, Pallai', '2023-12-24 14:30:00', 'B005', 'Active'),
('S0110', 'Selvam Rajendran', '1998-07-23', 26, '199812345684', 'selvam.raj@gmail.com', '0750123459', '89, New Town, Kilinochchi', '2024-04-03 09:30:00', 'B006', 'Active'),
('S0111', 'Arjun Sivananthan', '2002-02-20', 22, '200234567897', 'arjun.siv@gmail.com', '0771234560', '12, Coastal Road, Mullaitivu', '2024-02-14 13:00:00', 'B007', 'Active'),
('S0112', 'Priya Jeyaraj', '1994-11-05', 30, '199467890129', 'priya.jey@yahoo.com', '0712345661', '34, Fisher Street, Mulliyawalai', '2024-01-14 16:45:00', 'B008', 'Completed'),
('S0113', 'Kumaran Thangarajah', '2003-06-18', 21, '200378901240', 'kumaran.tha@gmail.com', '0763456762', '56, Temple Road, Puthukkudiyiruppu', '2024-03-14 12:15:00', 'B001', 'Active'),
('S0114', 'Anandi Kathiravel', '1991-03-30', 33, '199190123463', 'anandi.kat@hotmail.com', '0724567863', '78, Lake View, Mullaitivu', '2023-12-29 10:45:00', 'B002', 'Dropped'),
('S0115', 'Ravi Suthakar', '1999-12-12', 25, '199912345685', 'ravi.sut@gmail.com', '0755678964', '90, Main Street, Oddusuddan', '2024-04-04 15:00:00', 'B003', 'Active'),
('S0116', 'Shamil Zavahir', '2000-05-25', 24, '200034567898', 'shamil.zav@gmail.com', '0776789065', '23, Beach Road, Kalutara', '2024-02-16 11:15:00', 'B004', 'Active'),
('S0117', 'Nadeeka Jayamanna', '1995-02-08', 29, '199567890130', 'nadeeka.jay@yahoo.com', '0717890166', '45, River Road, Panadura', '2024-01-16 14:30:00', 'B005', 'Active'),
('S0118', 'Roshan De Mel', '2004-11-20', 20, '200478901241', 'roshan.dem@gmail.com', '0768901267', '67, Temple Road, Wadduwa', '2024-03-16 09:45:00', 'B006', 'Completed'),
('S0119', 'Asha Weeraratne', '1992-08-15', 32, '199290123464', 'asha.wee@hotmail.com', '0729012368', '89, Galle Road, Beruwala', '2023-12-31 16:00:00', 'B007', 'Active'),
('S0120', 'Thilina Nanayakkara', '1997-01-28', 27, '199712345686', 'thilina.nan@gmail.com', '0750123469', '12, Coast Road, Alutgama', '2024-04-06 12:45:00', 'B008', 'Active');

SELECT * FROM Student;