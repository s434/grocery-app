# Handover Strategy

1. Resolving Dependencies 
- Build the application and check the errors.
- Open .csproj file to check the version of .NET SDK and other package dependencies.
- Install the matching SDK.
- Restore the NuGet packages and install the missing ones.
- Install the missing dependencies (Identify it from the errors).
- Replace unsupported or outdated packages with alternatives.

2. Verify Configurations
- Check appsettings.json for database connection and jwt.
- Check environment variables and /API keys are valid. If not, replace them.

3. Check Database Connectivity
- Ensure if the database exists.
- Run migrations to update.
- Check if the schemas are still compatible.

4. Build The Application
- Build and run the application.
- Check for any errors (console included).
- Confirm if the logic of the application is correct.
- Use breakpoints to trace failures.

5. Document for future developers.
- Document application features and core business logic.
- Describe project architecture and folder responsibilities.
- Record setup steps required to run the project locally.
- List versions of .NET SDK, packages, and dependencies used.
- Capture known issues, assumptions, and debugging notes.

# Database Migration Strategy

To safely migrate `Price` from INTEGER to DECIMAL:

1. Create a New Column
   ```sql
   ALTER TABLE Products
   ADD Price_New DECIMAL(10,2);
   ```
## Database Migration Strategy

To safely migrate `Price` from INTEGER to DECIMAL:

2. Copy Existing Data

```sql
 UPDATE Products
SET Price_New = CAST(Price AS DECIMAL(10,2));
```
3. Validate Migrations
```sql
SELECT COUNT(*) 
FROM Products
WHERE Price_New IS NULL;
```

- Ensure result is zero.

4. Swap Columns
```sql
ALTER TABLE Products DROP COLUMN Price;
EXEC sp_rename 'Products.Price_New', 'Price', 'COLUMN';
```