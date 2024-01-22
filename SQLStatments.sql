-- Query for American cities with populations greater than 130,000:
SELECT C.Name 
FROM City C
JOIN Population P ON C.Id = P.CityId
WHERE C.CountryCode = 'USA' AND P.Population > 130000;

-- Query for the smallest city in Canada:
SELECT C.Name 
FROM City C
JOIN Population P ON C.Id = P.CityId
WHERE C.CountryCode = 'CN'
ORDER BY P.Population ASC
LIMIT 1;

-- Total population of each country, including the number of cities:
SELECT C.CountryCode, COUNT(C.Id) AS NumberOfCities, SUM(P.Population) AS TotalPopulation
FROM City C
JOIN Population P ON C.Id = P.CityId
GROUP BY C.CountryCode;

-- Top 3 cities with the highest population:
SELECT C.Name, P.Population
FROM City C
JOIN Population P ON C.Id = P.CityId
ORDER BY P.Population DESC
LIMIT 3;

-- City with the highest number of cars:
SELECT C.Name
FROM City C
JOIN CarAmount CA ON C.Id = CA.CityId
ORDER BY CA.Amount DESC
LIMIT 1;

-- Countries with more than 2 cities in the database:
SELECT CountryCode
FROM City
GROUP BY CountryCode
HAVING COUNT(Id) > 2;
