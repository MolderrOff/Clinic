import React, { useState, useEffect, useMemo, type ChangeEvent } from 'react';
import './App.css'; 



interface DiseaseData{
  id: string,
  name: string
}

interface FullNameData{
  name: string,
  surname: string
}

interface PatientData {
  id: string;
  patientName: FullNameData;
  diseaseId?: string | null;
  address: string;
}

interface DoctorData {
  id: string;
  fullName: FullNameData;
  diseases: DiseaseData[];
}

interface DoctorDiseaseRowData {
  doctorId: string;
  doctorFullName: FullNameData;
  diseaseName: string;
  diseaseId: string;
}

const Diseases: React.FC = () => {
  const [diseases, setDiseases] = useState<DiseaseData[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const API_URL = 'http://localhost:5185/api/diseases'; 

  const fetchData = async () : Promise<void> => {
    setIsLoading(true);
    setError(null); 
    setDiseases([]); 

    try {
      const response = await fetch(API_URL, {
        method: "GET",
        headers: {
           "Accept": "application/json"
           },
        });

      if (!response.ok) {
        throw new Error(`Ошибка HTTP: ${response.status}`);
      }

      const data: DiseaseData[] = await response.json();
      setDiseases(data);

    } catch (err: any) {
      console.error("Ошибка при получении данных:", err);
      setError('Не удалось загрузить данные из API.' + err.message);
      
    } finally {      
      setIsLoading(false);
    }
  };

  return (
    <div>
      <button 
        onClick={fetchData} 
        disabled={isLoading} 
      >
        {isLoading ? 'Загрузка...' : 'Загрузить список болезней'}
      </button>

      {isLoading && <p>Загрузка данных...</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}
      
      {diseases.length > 0 && (
        <div>
          <h3>Список болезней:</h3>
          <ul>
            {diseases.map((disease) => (
              <li key={disease.id} style={{ marginBottom: '10px' }}>
                 <strong>ID</strong> {disease.id}  
                 
                <strong>{disease.name}</strong>    
              </li>
            ))}            
          </ul>
        </div>
      )}

      {!isLoading && !error && diseases.length === 0 && (
          <p>Нажмите кнопку, чтобы загрузить данные.</p>          
      )}
    </div>
  );
};

const PatientList: React.FC = () => {
  const[patients, setPatients] = useState<PatientData[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const API_URL = 'http://localhost:5185/api/patients';

  const fetchPatients = async () : Promise<void> => {
    setIsLoading(true);
    setError(null);

    try {
      const response = await fetch(API_URL, {
        method: "GET",
        headers: {
          "Accept": "application/json",
        },
      });

      if (!response.ok) {
        throw new Error(`Ошибка HTTP: ${response.status}`);
      }

      const data: PatientData[] = await response.json();
      setPatients(data);

    } catch (err: any) {
      console.error("Ошибка при получении данных:", err);
      setError('Не удалось загрузить данные о пациентах: ' + err.message);
      
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div>
      <h1>Список пациентов</h1>
      <button onClick={fetchPatients} disabled={isLoading}>
        {isLoading ? 'Загрузка данных...' : 'Обновить список пациентов'}
      </button>

      {isLoading && <p>Загрузка данных ...</p>}
      {error && <p style = {{ color: 'red' }}>{error}</p>}

      {patients.length > 0 ? (
        <ul>
          {patients.map((patient) => (
            <li key={patient.id} style={{marginBottom: '15px'}}>
              <strong>ID:</strong> {patient.id} 
              <br />
              <strong>Имя:</strong> {patient.patientName?.name} {patient.patientName?.surname}
              <br />
              <strong>Адрес:</strong> {patient.address}
              <br />
              <strong>ID Болезни</strong> {patient.diseaseId || 'Не указан'}
            </li>
          ))}
        </ul>
      ) : (
        !isLoading && <p>Пациенты не найдены.</p>
      )}
    </div>
  );
};

const PatientDetails: React.FC = () => {
  const [patient, setPatient] = useState<PatientData | null>(null);
  const [searchId, setSearchId] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const [notFound, setNotFound] = useState<boolean>(false);

  const API_URL = 'http://localhost:5185/api/patients';

  const handleIdChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchId(event.target.value);
  };

  const fetchPatientById = async () : Promise<void> => {
    setIsLoading(true);
    setError(null);
    setNotFound(false);
    setPatient(null);

    if (!searchId || searchId.length !== 36) {
      setError("Пожалуйста, введите корректный ID (GUID).");
      setIsLoading(false);
      return;
    }
    try {
      const response = await fetch(`${API_URL}/${searchId}`, {
        method: "GET",
        headers: {
          "Accept": "application/json",          
        },
      });

      if (response.status === 404) {
        setNotFound(true);
        return;
      }

      if (!response.ok) {
        throw new Error(`Ошибка HTTP: ${response.status}`);
      }

      const data: PatientData = await response.json();
      setPatient(data);

    } catch (err: any) {
      console.error("Ошибка при получении данных: ", err);
      setError('Не удалось загрузить данные о пациенте:' + err.message);

    } finally {
      setIsLoading(false);
    }
  }; 
  
  return (
    <div>
      <h1>Поиск пациента по ID</h1>
      <div>
        <input
          type="text"
          placeholder="Введите ID пациента (GUID)"
          value={searchId}
          onChange={handleIdChange}
          style={{ width: '300px', marginRight: '10px'}}
        />
        <button onClick={fetchPatientById} disabled={isLoading}>
          {isLoading ? 'Поиск...' : 'Найти пациента'}
        </button>
      </div>

      {isLoading && <p>Загрузка данных...</p>}
      {error && <p style={{color : 'red'}}>{error}</p>}
      {notFound && <p style={{color: 'orange'}}>Пациент с таким ID не найден</p>}

      {patient && (
        <div style={{ marginTop: '20px', border: '1px solid green', padding: '15px' }}>
          <h3>Информация о пациенте:</h3>
          <p><strong>ID:</strong> {patient.id}</p>
          <p><strong>Имя:</strong> {patient.patientName?.name} {patient.patientName?.surname}</p>
          <p><strong>Адрес:</strong> {patient.address}</p>
          <p><strong>ID Болезни:</strong> {patient.diseaseId || 'Не указан'}</p>
        </div>
      )}
    </div>
  );
};

const PatientUpdater : React.FC = () =>{
  const [inputId, setInputId] = useState<string>('');
  const[patient, setPatient]=useState<PatientData | null>(null);

  const[nameInput, setNameInput]=useState<string>('');
  const[surnameInput, setSurnameInput]=useState<string>('');
  const[addressInput, setAddressInput]=useState<string>('');
  const [diseaseIdInput, setDiseaseIdInput] = useState<string>('');

  const[isLoading, setIsLoading]=useState<boolean>(false);
  const[error, setError]=useState<string | null>(null);
  const[message, setMessage]=useState<string | null>(null);

  const API_READ_URL = 'http://localhost:5185/api/patients';
  const API_UPDATE_URL = 'http://localhost:5185/api/patient-update';
 
  const fetchPatientData = async (): Promise<void> => {
    setIsLoading(true);
    setError(null);
    setMessage(null);
    setPatient(null);

    if (!inputId) {
      setError('Пожалуйста, введите ID');
      setIsLoading(false);
      return;
    }

    try{
      const response = await fetch(`${API_READ_URL}/${inputId}`);
      if (response.status === 404) {
        setError("Пациента с таким ID не найден.");
        return;
      }
      if (!response.ok) throw new Error("Не удалось загрузить данные пациента");

      const data: PatientData = await response.json();
      setPatient(data);

      setNameInput(data.patientName?.name || '');
      setSurnameInput(data.patientName?.surname || '');
      setAddressInput(data.address || '');
      setDiseaseIdInput(data.diseaseId || '');

    } catch (e: any){
      setError(e.message);
    } finally {
      setIsLoading(false);
    }
  };

  const handleUpdatePatient = async(): Promise<void> => {
    if (!patient) return;

    setIsLoading(true);
    setError(null);
    setMessage(null);

    const updatePatientDTO = {
      patientName: {
        name: nameInput,
        surname: surnameInput,
      },
      diseaseId: diseaseIdInput,
      address: addressInput,      
    };

    try {
      const response = await fetch(`${API_UPDATE_URL}/${patient.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updatePatientDTO),
      });

      const responseText = await response.text(); 

      if (!response.ok) {

        throw new Error(`Ошибка API (${response.status}): ${responseText || response.statusText}`);
        
      }
      
      setMessage(responseText || "Успешно.");


    } catch(err: any) {
      setError('Не удалось обновить данные: ' + err.message);

    } finally{
      setIsLoading(false);
    }
  };

  return (
    <div>
      <h1>Обновление данных пациента</h1>
      <div>
        <input
        type="text"
        placeholder='Введите ID пациента (GUID)'
        value={inputId}
        onChange={(e) => setInputId(e.target.value)}
        style={{width: '300px', marginRight: '10px'}}
        />
        <button onClick={fetchPatientData} disabled={isLoading}>
          {isLoading ? 'Загрузка....' : 'Загрузить данные'}
        </button>
      </div>

      {error && <p style={{color: 'red'}}>{error}</p>}
      {message && <p style={{color: 'green'}}>{message}</p>}

      {patient && (
        <div style={{ marginTop: '20px', border: '1px solid #ccc', padding: '15px'}}>
          <h3>Редактирование пациента ID: {patient.id}</h3>

          <label>Имя: </label>
          <input type="text" value={nameInput} onChange={(e) => setNameInput(e.target.value)} />
          <br />
          <label>Фамилия: </label>
          <input type="text" value={surnameInput} onChange={(e) => setSurnameInput(e.target.value)} />
          <br />
          
          <label>Адрес: </label>
          <input type="text" value={addressInput} onChange={(e) => setAddressInput(e.target.value)} />
          <br />

          <label>ID Болезни: </label>
          <input type="text" value={diseaseIdInput} onChange={(e) => setDiseaseIdInput(e.target.value)} />
          <br />

          <button onClick={handleUpdatePatient} disabled={isLoading}>
            {isLoading ? 'Обновление...' : 'Сохранить изменения'}
          </button>
         </div>
      )}         
    </div>
  );
};

const DoctorListWithDiseases: React.FC = () => {
  const [doctors, setDoctors] = useState<DoctorData[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const API_URL = 'http://localhost:5185/api/doctors';

  const fetchData = async () => {
    setIsLoading(true);
    setError(null);
    setDoctors([]); 
    try {
      const response = await fetch(API_URL);
      if (!response.ok) throw new Error("Не удалось загрузить докторов");
      const data: DoctorData[] = await response.json();
      setDoctors(data);
    } catch (e: any) {
      setError(e.message);
    } finally {
      setIsLoading(false);
    }
  };
  
  

  if (isLoading) return <p>Загрузка данных...</p>;
  if (error) return <p style={{color: 'red'}}>{error}</p>;

  return (
    <div>
      <h1>Информация о докторах и их болезнях</h1>
      
      
      <button onClick={fetchData} disabled={isLoading}>
        {isLoading ? 'Загрузка...' : 'Загрузить данные о докторах'}
      </button>

      
      {doctors.length === 0 && !isLoading && !error && (
        <p>Нажмите кнопку, чтобы загрузить информацию.</p>
      )}

      
      {doctors.length > 0 && (
        <table>
          <thead>
            <tr>
              <th>Название Болезни</th>
              <th>Доктор</th>                       
            </tr>
          </thead>
          <tbody>
            {doctors.map((doctor) => {
              
              if (doctor.diseases && doctor.diseases.length > 0) {
                return doctor.diseases.map((disease) => (
                  <tr key={`${doctor.id}-${disease.id}`}>
                    <td>{disease.name}</td>
                    <td>{doctor.fullName?.name} {doctor.fullName?.surname}</td>                    
                  </tr>
                ));
              } else {
                return (
                  <tr key={doctor.id}>
                    <td>{doctor.fullName?.name}</td>
                    <td>{doctor.fullName?.surname}</td>
                    <td>Нет данных о болезни</td>
                  </tr>
                );
              }
            })}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default function AppAll(){
  return (
    <div>    
      <Diseases />
      <PatientList />
      <PatientDetails />
      <PatientUpdater />      
      <DoctorListWithDiseases />
    </div>
  )
};