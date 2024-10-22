pipeline{
    agent any
    triggers {
        pollSCM('* * * * *')
    }
    
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                sh "dotnet build LoggingApi/LoggingApi.csproj"
            }
        } 
        stage('Test') {
            steps { 
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
    
}