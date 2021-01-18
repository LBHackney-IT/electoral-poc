// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1056:Uri properties should not be strings", Justification = "<Pending>", Scope = "member", Target = "~P:ElectoralPOC.V1.Boundary.Response.GeneratePreSignedUrlResponse.Url")]
[assembly: SuppressMessage("Design", "CA1055:Uri return values should not be strings", Justification = "<Pending>", Scope = "member", Target = "~M:ElectoralPOC.V1.UseCase.GetPreSignURLUseCase.GetS3PutPresignUrl~System.String")]
[assembly: SuppressMessage("Design", "CA1055:Uri return values should not be strings", Justification = "<Pending>", Scope = "member", Target = "~M:ElectoralPOC.V1.Infrastructure.AWSS3Client.GenerateS3PreSignURL(ElectoralPOC.V1.Boundary.Request.GenerateS3PreSignedUrlRequest)~System.String")]
[assembly: SuppressMessage("Design", "CA1055:Uri return values should not be strings", Justification = "<Pending>", Scope = "member", Target = "~M:ElectoralPOC.V1.Infrastructure.IAwsS3Client.GenerateS3PreSignURL(Amazon.S3.Model.GetPreSignedUrlRequest)~System.String")]
[assembly: SuppressMessage("Design", "CA1055:Uri return values should not be strings", Justification = "<Pending>", Scope = "member", Target = "~M:ElectoralPOC.V1.Infrastructure.AWSS3Client.GenerateS3PreSignURL(Amazon.S3.Model.GetPreSignedUrlRequest)~System.String")]
